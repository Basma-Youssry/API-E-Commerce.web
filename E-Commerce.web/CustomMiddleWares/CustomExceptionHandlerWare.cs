using System.Net;
using DomainLayer.Exceptions;
using E_Commerce.web.ErrorModels;

namespace E_Commerce.web.CustomMiddleWares
{
    public class CustomExceptionHandlerWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerWare> _logger;

        public CustomExceptionHandlerWare(RequestDelegate Next, ILogger<CustomExceptionHandlerWare> logger)
        {
            _next = Next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await NewMethod(httpContext);
        }

        private async Task NewMethod(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);

                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Somthing went wrrong");

                await HandleExceptionAsync(httpContext, ex);

            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            //Response object
            var Response = new ErrorToReturn()
            {
                //StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message
            };
            //Set status code for response
            //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                BadRequestException  badRequestException => GetBadRequetErrors(badRequestException, Response),
                _ => StatusCodes.Status500InternalServerError
            };

            //Set content type for response
            //httpContext.Response.ContentType = "application/json";


            //Return object as Json
            httpContext.Response.StatusCode = Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(Response);
        }

        private static int GetBadRequetErrors(BadRequestException badRequestException, ErrorToReturn response)
        {
            response.Errors = badRequestException.Errors;
            return StatusCodes.Status400BadRequest;
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                };

                await httpContext.Response.WriteAsJsonAsync(Response);
            }
        }
    }
}
