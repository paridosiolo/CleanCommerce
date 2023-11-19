using CleanCommerce.Domain.Common.Errors;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Errors
{
    public partial class ApplicationErrors
    {
        public static class Validation
        {
            public static ErrorBase Generic(
                string code = "Validation.Generic",
                string message = "A validation error has occurred.") =>
                new ErrorBase(code, ErrorType.Validation, message);

            public static ErrorBase EmptyField(
                string code = "Validation.EmptyField",
                string message = "This field cannot be empty.") =>
                new ErrorBase(code, ErrorType.Validation, message);
        }
    }
}
