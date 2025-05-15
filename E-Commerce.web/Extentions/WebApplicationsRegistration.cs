using System.Text.Json;
using DomainLayer.Contracts;
using E_Commerce.web.CustomMiddleWares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace E_Commerce.web.Extentions
{
    public static class WebApplicationsRegistration
    {
        public static async Task<WebApplication> SeedDataBaseAsync(this WebApplication app)
        {

            var scoope = app.Services.CreateScope();
            var ObjectOfDataSeeding = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();

            await ObjectOfDataSeeding.DataSeedAsync();
            await ObjectOfDataSeeding.IdentityDataSeedAsync();

            return app;
        }

        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerWare>();

            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddleWares(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(Options =>
            {
                Options.ConfigObject = new ConfigObject()
                {
                    DisplayRequestDuration = true
                };

                Options.DocumentTitle = "My E-Commerce API";

                Options.JsonSerializerOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                Options.DocExpansion(DocExpansion.None);

                Options.EnableFilter();

                Options.EnablePersistAuthorization();                                                                                                                                                                                               
            });

            return app;
        }
    }
}
