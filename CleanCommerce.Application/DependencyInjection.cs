using CleanCommerce.Application.Authentication.Commands.Register;
using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Common.Behaviors;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return serviceCollection;
        }
    }
}
