using Contracts;
using System.Net;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Entities.Exceptions;


namespace CompanyEmployees.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
       
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {

           // logger.LogInfo("1");
            app.UseExceptionHandler(appError =>
            {
                //logger.LogInfo("2");
                appError.Run(async context =>
                {
                    logger.LogInfo("3");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                   // logger.LogInfo("4");
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //logger.LogInfo("5");

                        context.Response.StatusCode = contextFeature.Error switch
                        {

                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        //logger.LogInfo("6");
                        logger.LogError($"Something went wrong : {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                           Message = contextFeature.Error.Message
                          // Message="Internal server error"
                           
                        }.ToString());
                        //logger.LogInfo("7");

                    }
                });
            });
        }
    }
}
