using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories;
using Talabat.Repository;
using TalabatAPIs.Errors;
using TalabatAPIs.Helpers;

namespace TalabatAPIs.Extentions
{
    public  static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApllicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IBasketRepository),typeof(BasketRepository));

            services.AddAutoMapper(typeof(mappingProfiles));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {

                    var errors = ActionContext.ModelState.Where(P => P.Value.Errors.Count > 0)
                                                          .SelectMany(p => p.Value.Errors)
                                                          .Select(E => E.ErrorMessage)
                                                          .ToArray();

                    var validationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });

            return services;
        }
    }
}
