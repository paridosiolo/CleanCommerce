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
        public static class Categories
        {
            public static ErrorBase CategoryNotFound(
                string code = "Categories.NotFound",
                string categoryId = "Default") =>
                new ErrorBase(code, ErrorType.NotFound, $"Following CategoryId was not found: {categoryId}");

            public static ErrorBase CouldNotDelete(
                string code = "Categories.CouldNotDelete",
                string categoryId = "Default") =>
                new ErrorBase(code, ErrorType.Failure, $"Could not delete the following category: {categoryId}");
        }
    }
}
