using E_Commerce.web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.web.Extentions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            return Services;
        }

        public static IServiceCollection AddWepApplicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>((Options) =>
            {

                Options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorsResponse;

            });
            return Services;
        }
    }
}
