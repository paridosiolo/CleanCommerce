using CleanCommerce.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Common.Errors
{
    public static partial class InfrastructureErrors
    {
        public static class Authorization
        {
            public static readonly ErrorBase UserNotFound = new ErrorBase(
                "Authorization.UserNotFound", ErrorType.NotFound,
                "User not found");

            public static readonly ErrorBase NotAuthorized = new ErrorBase(
                "Authorization.NotAuthorized", ErrorType.Unauthorized,
                "User not authorized");
        }
    }
}
