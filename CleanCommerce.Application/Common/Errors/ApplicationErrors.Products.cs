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
        public static class Products
        {
            public static ErrorBase ProductNotFound(
                string code = "Products.NotFound",
                string productId = "Default") =>
                new ErrorBase(code, ErrorType.NotFound, $"Following ProductId was not found: {productId}");

            public static ErrorBase CouldNotDelete(
                string code = "Products.CouldNotDelete",
                string productId = "Default") =>
                new ErrorBase(code, ErrorType.Failure, $"Could not delete the following product: {productId}");
        }
    }
}
