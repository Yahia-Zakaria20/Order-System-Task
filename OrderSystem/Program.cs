
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Errors;
using OrderSystem.Middlewares;

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

            webApplicationBuilder.Services.Configure<ApiBehaviorOptions>(option => {

                option.InvalidModelStateResponseFactory = (actiocontext) =>
                {

                    var errors = actiocontext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                   .SelectMany(e => e.Value.Errors)
                                                    .Select(p => p.ErrorMessage)
                                                     .ToList();

                    var ApiValidationError = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(ApiValidationError);
                };


            });
            #endregion

            var app = webApplicationBuilder.Build();


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
