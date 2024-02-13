using CleanCommerce.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Errors
{
    public static partial class ApplicationErrors
    {
        public static class Carts
        {
            public static ErrorBase CartNotFound(
                string code = "Carts.NotFound",
                string cartId = "Default") =>
                new ErrorBase(code, ErrorType.NotFound, $"Following CartId was not found: {cartId}");

            public static ErrorBase CouldNotDelete(
                string code = "Carts.CouldNotDelete",
                string cartId = "Default") =>
                new ErrorBase(code, ErrorType.Failure, $"Could not delete the following cart: {cartId}");
        }
    }
}
