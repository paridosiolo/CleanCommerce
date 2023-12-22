using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Application.Common.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using System.Reflection;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Common.Errors;

namespace CleanCommerce.Application.Common.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IAuthorizableRequest<TResponse>
    {
        private readonly IAuthorizeService _authorizationService;
        public AuthorizationBehavior(IAuthorizeService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizationAttributes = request.GetType()
            .GetCustomAttributes<AuthorizeAttribute>()
            .ToList();

            if (authorizationAttributes.Count == 0)
            {
                return await next();
            }

            var requiredRoles = authorizationAttributes
                .SelectMany(authorizationAttribute => authorizationAttribute.Roles?.Split(',') ?? Array.Empty<string>())
                .ToList();

            var authorizationResult = _authorizationService.AuthorizeCurrentUser(request, requiredRoles);

            if (authorizationResult.IsSuccess)
            {
                return await next();
            }

            var errors = authorizationResult.Errors.ConvertAll(error => ApplicationErrors.Authorization.Unauthorized(
                error.GetCode(), error.Message));

            return (dynamic)Result.Fail(errors);
        }
    }
}
