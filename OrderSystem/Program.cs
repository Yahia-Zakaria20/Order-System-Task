
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Errors;
using OrderSystem.Middlewares;
using OrderSystem.RepositoryLayer.Data;
using StackExchange.Redis;

namespace OrderSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configer Services
            // Add services to the container.

            webApplicationBuilder.Services.AddControllers();

            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();


            webApplicationBuilder.Services.AddDbContext<ApplicationDbcontext>(options => 
            {
                options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefultConnection"));
            });

           webApplicationBuilder.Services.ApplicationsServices();

            webApplicationBuilder.Services.AddSingleton<IConnectionMultiplexer>((options) =>
            {
                return ConnectionMultiplexer.Connect(webApplicationBuilder.Configuration.GetConnectionString("Redis"));
            });
            #endregion

            var app = webApplicationBuilder.Build();

            var Scope =  app.Services.CreateScope();

             var services = Scope.ServiceProvider;

             var dbcontext  =  services.GetRequiredService<ApplicationDbcontext>();
             var LoggerFactory =   services.GetRequiredService<ILoggerFactory>();


            try
            {
                dbcontext.Database.Migrate();
            }
            catch (Exception ex)
            {
               var logger = LoggerFactory.CreateLogger<Program>();

                logger.LogError(string.Empty,ex.Message);   
            }
          



            #region Configer Kestrel Middleware

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
