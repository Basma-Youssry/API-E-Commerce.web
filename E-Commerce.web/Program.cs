

using DomainLayer.Contracts;
using E_Commerce.web.CustomMiddleWares;
using E_Commerce.web.Extentions;
using E_Commerce.web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Service;
using ServiceAbstraction;
using Shared.ErrorModels;

namespace E_Commerce.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            #region Add Services to Container
            builder.Services.AddControllers();
            builder.Services.AddSwaggerServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AppApplicationServices();
            builder.Services.AddWepApplicationServices();
            builder.Services.AddJWTService(builder.Configuration);
            #endregion


            var app = builder.Build();

            await app.SeedDataBaseAsync();

            // Configure the HTTP request pipeline.

            app.UseCustomExceptionMiddleWare();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleWares();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
