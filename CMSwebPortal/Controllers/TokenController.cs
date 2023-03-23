using CMSwebPortal.DataLayer;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.Authentication.RefreshTokenRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSwebPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenRepository _Token;
        public TokenController(ApplicationDbContext ctx, ITokenRepository service)
        {
            this._db = ctx;
            this._Token = service;

        }
        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="tokenApiModel"></param>
        /// <returns></returns>
        [HttpPost("Refresh")]
        public IActionResult Refresh(RefreshTokenRequest tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = _Token.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _db.TokenInfo.SingleOrDefault(u => u.Usename == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = _Token.GetToken(principal.Claims);
            var newRefreshToken = _Token.GetRefreshToken();
            user.RefreshToken = newRefreshToken;
            _db.SaveChanges();
            return Ok(new RefreshTokenRequest()
            {
                AccessToken = newAccessToken.TokenString,
                RefreshToken = newRefreshToken
            });
        }
        /// <summary>
        /// Revoke Method use Removing token entry
        /// </summary>
        /// <returns></returns>
        //revoken is use for removing token entry
        [HttpPost("Revoke"), Authorize]
        public IActionResult Revoke()
        {
            try
            {
                var username = User.Identity.Name;
                var user = _db.TokenInfo.SingleOrDefault(u => u.Usename == username);
                if (user is null)
                    return BadRequest();
                user.RefreshToken = null;
                _db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
