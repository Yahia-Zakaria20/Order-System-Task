using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using OrderSystem.Errors;
using OrderSystem.Helper;
using OrderSystem.RepositoryLayer;

namespace OrderSystem.Middlewares
{
    public static class ApplicationExtentionservices
    {

        public static IServiceCollection ApplicationsServices(this IServiceCollection services) 
        {
           services.Configure<ApiBehaviorOptions>(option => {

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

            services.AddScoped<IBasketRepositry, BasketRepositry>();

            services.AddAutoMapper(o => o.AddProfile(new MappingProfile()));

            return services;

        }


       

    }
}
