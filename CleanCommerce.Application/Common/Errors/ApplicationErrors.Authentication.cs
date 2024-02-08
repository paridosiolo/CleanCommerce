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
    public static partial class ApplicationErrors
    {
        public static class Authentication
        {
            public static readonly ErrorBase DuplicateEmail = new ErrorBase(
                "Authentication.DuplicateEmail", 
                ErrorType.Conflict,
                "User with this email already exists"
                );

            public static readonly ErrorBase InvalidPassword = new ErrorBase(
                "Authentication.InvalidPassword",
                ErrorType.Unauthorized,
                "An invalid password was provided");

            public static readonly ErrorBase UserNotFound = new ErrorBase(
                "Authentication.UserNotFound", 
                ErrorType.NotFound,
                "User not found");
        }
    }
}
