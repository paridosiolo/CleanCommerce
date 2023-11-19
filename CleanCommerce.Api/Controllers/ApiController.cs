using CleanCommerce.Api.Common.Http;
using CleanCommerce.Domain.Common.Errors;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanCommerce.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<IError> errors)
        {
            HttpContext.Items[HttpContextKeys.Errors] = errors;
            if (errors.All(error => error.IsValidationError()))
            {
                return ValidationProblem(errors);
            }
            var firstError = errors.First();

            return Problem(firstError);
        }

        private IActionResult Problem(IError firstError)
        {
            /* Warning: should not return error details in production 
             * to avoid security issues (e. g. credential guessing) */

            var statusCode = firstError.GetErrorType() switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,

                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, title: firstError.Message);
        }

        private IActionResult ValidationProblem(List<IError> errors)
        {
            var modelState = new ModelStateDictionary();

            foreach (var error in errors)
            {
                var field = error.GetCode();
                var message = error.Message;
                modelState.AddModelError(field, message);
            }

            return ValidationProblem(modelState);
        }
    }
}
