using CleanCommerce.Application.Common.Interfaces.Authentication;
using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Interfaces.Services;
using CleanCommerce.Infrastructure.Authentication;
using CleanCommerce.Infrastructure.Common.Security;
using CleanCommerce.Infrastructure.Persistence;
using CleanCommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection serviceCollection,
            ConfigurationManager configuration)
        {
            serviceCollection.AddAuth(configuration);
            serviceCollection.AddPersistence();
            serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
            serviceCollection.AddScoped<IAuthorizeService, AuthorizeService>();

            return serviceCollection;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            return serviceCollection;
        }
        private static IServiceCollection AddAuth(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            //create options to  for jwt generator
            serviceCollection.AddSingleton(Options.Create(jwtSettings));
            serviceCollection.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            serviceCollection.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(jwtSettings.Secret))
                    };
                });

            return serviceCollection;
        }
    }
}
