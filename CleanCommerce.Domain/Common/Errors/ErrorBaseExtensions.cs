using CleanCommerce.Domain.Common.Errors;
using FluentResults;

namespace CleanCommerce.Domain.Common.Errors
{
    public static class ErrorBaseExtensions
    {
        public static bool IsValidationError(this IError error)
        {
            return (ErrorType)error.Metadata[ErrorBase.TYPE] == ErrorType.Validation;
        }
        public static ErrorType GetErrorType(this IError error)
        {
            return (ErrorType)error.Metadata[ErrorBase.TYPE];
        }
        public static string GetCode(this IError error)
        {
            return error.Metadata[ErrorBase.CODE].ToString()!;
        }
    }
}
