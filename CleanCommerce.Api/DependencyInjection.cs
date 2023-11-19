using CleanCommerce.Api.Common.Errors;
using CleanCommerce.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanCommerce.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<ProblemDetailsFactory, CleanCommerceProblemDetailsFactory>();
            services.AddControllers();
            services.AddMapping();

            return services;
        }
    }
}
