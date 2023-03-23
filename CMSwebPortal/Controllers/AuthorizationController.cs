using CMSwebPortal.DataLayer;
using CMSwebPortal.DataLayer.Data;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.Authentication.ForgetPasswordModel;
using CMSwebPortal.Models.Authentication.LoginModel;
using CMSwebPortal.Models.Authentication.SignUpModel;
using CMSwebPortal.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenRepository _tokenService;
        private readonly ISendgridEmailRepository _sendgridEmailRepository;
        private readonly IEmailRepository _emailRepository;

        public AuthorizationController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenRepository tokenService
,
            ISendgridEmailRepository sendgridEmailRepository,
            IEmailRepository emailRepository)
        {
            this._db = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._tokenService = tokenService;
            _sendgridEmailRepository = sendgridEmailRepository;
            _emailRepository = emailRepository;
        }
        /// <summary>
        /// Change Password
        /// </summary>
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var status = new Status();
            // check validations
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "please pass all the valid fields";
                return Ok(status);
            }
            // lets find the user
            var user = await userManager.FindByNameAsync(model.Username);
            if (user is null)
            {
                status.StatusCode = 0;
                status.Message = "invalid username";
                return Ok(status);
            }
            // check current password
            if (!await userManager.CheckPasswordAsync(user, model.CurrentPassword))
            {
                status.StatusCode = 0;
                status.Message = "invalid current password";
                return Ok(status);
            }

            // change password here
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Failed to change password";
                return Ok(status);
            }
            status.StatusCode = 1;
            status.Message = "Password has changed successfully";
            return Ok(result);
        }
        /// <summary>
        ///login Admin and User
        /// </summary>

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
          //if you click then first of all user emil link comfirmed then login otherwise invalied username and password

            //  if (user != null && await userManager.CheckPasswordAsync(user, model.Password) && user.EmailConfirmed)
          if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = _tokenService.GetToken(authClaims);
                var refreshToken = _tokenService.GetRefreshToken();
                var tokenInfo = _db.TokenInfo.FirstOrDefault(a => a.Usename == user.UserName);
                if (tokenInfo == null)
                {
                    var info = new TokenInfo
                    {
                        Usename = user.UserName,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiry = DateTime.Now.AddDays(1)
                    };
                    _db.TokenInfo.Add(info);
                }

                else
                {
                    tokenInfo.RefreshToken = refreshToken;
                    tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                }
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
               


                return Ok(new LoginResponse
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Token = token.TokenString,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    StatusCode = 1,
                    Message = "Logged in"
                });

            }
            //login failed condition

            return Ok(
                new LoginResponse
                {
                    StatusCode = 0,
                    Message = "Invalid Username or Password",
                    Token = "",
                    Expiration = null
                });
        }
        /// <summary>
        /// New User Register 
        /// </summary>
        /// <param name="Registration With User"></param>
        /// <remarks>
        /// sample request:
        /// 
        /// {
        /// 
        /// "UserName":"Jasmin",
        /// 
        /// "Email":"Jasmin@gmail.com",
        /// 
        /// "Password":"malik@123",
        /// 
        /// }
        /// </remarks>
        /// 
        /// 
        /// <returns>kazim</returns>
        /// <response code="200">Create a tag in the system</response>
        /// <response code="400">Unable to Create the tag due to validation error</response>

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] SignUpModel model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.Name
            };
            // create a user here
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }

            //send email through smtp server mimekit

            var emailgenerate = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { emailgenerate, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email! }, "Confirmation Email Link", confirmationLink!);
              _emailRepository.SendEmail(message);



            // simple email send through sendgrid

           await _sendgridEmailRepository.SendEmail(model.Name, model.Email, "<h1>Welcome 11Values</h1><p>New Singup to your Account at "+DateTime.Now+  "</p>");
           status.StatusCode = 1;
           status.Message = "Sucessfully registered";
           return Ok(status);

        }

        //Not show api in  browser 
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user,token);
                if (result.Succeeded)
                {
                    return (ActionResult)StatusCode(StatusCodes.Status200OK, new ResponseMes { Status = "Success", Message = "Email Confirm Successfully!" });
                }
            }
            return (ActionResult)StatusCode(StatusCodes.Status500InternalServerError, new ResponseMes { Status = "Err0r", Message = "This User Does Not Exist!" });
        }

        // after registering admin we will comment this code, because i want only one admin in this application
        /// <summary>
        /// New Admin Register 
        /// </summary>
        /// <param name="Registration With Admin"></param>

        [HttpPost("RegistrationAdmin")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] SignUpModel model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.Name
            };
            // create a user here
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            status.StatusCode = 1;
            status.Message = "Sucessfully registered";
            return Ok(status);

        }

    }
}
