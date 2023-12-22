using CleanCommerce.Application.Common.Security.Request;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Interfaces.Services
{
    public interface IAuthorizeService
    {
        Result<Success> AuthorizeCurrentUser<T>(
            IAuthorizableRequest<T> request,
            List<string> requiredRoles);
    }
}
