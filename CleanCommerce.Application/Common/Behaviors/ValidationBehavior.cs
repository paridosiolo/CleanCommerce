using CleanCommerce.Application.Authentication.Commands.Register;
using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Common.Errors;
using FluentResults;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Behaviors
{
       public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(validationFailure => ApplicationErrors.Validation.Generic(
                validationFailure.PropertyName, validationFailure.ErrorMessage));

            return (dynamic) Result.Fail(errors);
        }
    }
}
