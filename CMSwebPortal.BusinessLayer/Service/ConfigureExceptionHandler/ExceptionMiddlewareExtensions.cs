using CMSwebPortal.Common.Enums;
using CMSwebPortal.Models.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
namespace CMSwebPortal.BusinessLayer.ConfigureExceptionHandler
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// This extension method is used as global exception handler and logs the exceptions on SEQ
        /// This extension method is created for WebApplication type. And register as a middleware in program.cs
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.ToString());
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(GenericApiResponse<bool>.Failure(contextFeature.Error.InnerException.ToString(), ApiStatusCode.InternalServerError)));
                    }
                });
            });
        }
    }
}
