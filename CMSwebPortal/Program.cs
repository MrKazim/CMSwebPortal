using CMSwebPortal.BusinessLayer.ConfigureExceptionHandler;
using CMSwebPortal.BusinessLayer.IService;
using CMSwebPortal.BusinessLayer.Service;
using CMSwebPortal.DataLayer;
using CMSwebPortal.DataLayer.Data;
using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.DataLayer.Infrastructure.Repository;
using CMSwebPortal.Models.Authentication.EmailConfigurationModel;
using CMSwebPortal.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// For Entity Framework  
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//implements default schema data with response classes 
builder.Services.AddSwaggerExamplesFromAssemblyOf<OfficialDataByIdSwagger>();

//Swagger Implementation

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Api", Version = "v1", Description = "This API is Useful Content Management System." });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // pick comments from classes, include controller comments: another tip from StackOverflow
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    // enable the annotations on Controller classes [SwaggerTag]
    // options.EnableAnnotations();
    options.ExampleFilters();
    // to allow for a header parameter
    /// options.OperationFilter<AddRequiredHeaderParameter>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            }, new string[] {}
        }
    });
});

//add cors policy connection 
builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod().
        AllowAnyHeader();
    });
});

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddScoped<IMenuRepository,MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddScoped<IOfficialRepository,OfficialRepository>();   
builder.Services.AddScoped<IOfficialService,OfficialService>();

builder.Services.AddScoped<ISecurityCommitteeRepository,SecurityCommitteeRepository>(); 
builder.Services.AddScoped<ISecurityCommitteeService,SecurityCommitteeService>();   

builder.Services.AddScoped<IWorkRepository,WorkRepository>();
builder.Services.AddScoped<IWorkService,WorkService>(); 

builder.Services.AddScoped<IActivityRepository,ActivityRepository>();   
builder.Services.AddScoped<IActivityService,ActivityService>();

builder.Services.AddScoped<IUpsertingRepository,UpsertingRepository>(); 
builder.Services.AddScoped<IUpsertingService,UpsertingService>();   

//Add Pipeline through files
builder.Services.AddScoped<IFileService, FileService>();

//pipeline email through sendgridemail

builder.Services.AddScoped<ISendgridEmailRepository,SendgridEmailRepository>();

//Configure EmailConfiguration Pipelines

var emailConfig =builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailRepository, EmailRepository>();    

//verification for login if signup then email confimed receive then way to login otherwise username and password show error
//add email configuration
builder.Services.Configure<IdentityOptions>(options =>
    options.SignIn.RequireConfirmedEmail = true);

var app = builder.Build();

// Configure the HTTP request pipeline.


// To configuer Exception handling 
app.ConfigureExceptionHandler(app.Logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   // app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
       c.SwaggerEndpoint("https://localhost:7068/swagger/v1/swagger.json", "Auth API");
       c.DocumentTitle = "AuthApi";
       c.InjectStylesheet("/swagger-custom/swagger-custom-styles.css");
       c.InjectJavascript("/swagger-custom/swagger-custom-script.js", "text/javascript");
      // c.RoutePrefix = string.Empty;
    });
}
app.UseStaticFiles();
app.UseHttpsRedirection();
//use cors policy
app.UseCors("mypolicy");
//Authentication use between UseHttpsRedirection and UseAuthorizatin
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
