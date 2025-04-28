using System.Net;
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
            try
            {
              await _next.Invoke(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Somthing went wrrong");

                //Set status code for response
                //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                //Set content type for response
                //httpContext.Response.ContentType = "application/json";

                //Response object
                var Response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };

                //Return object as Json
                await httpContext.Response.WriteAsJsonAsync(Response);
                
            }
        }
    }
}
