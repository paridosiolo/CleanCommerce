using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Interfaces.Services;
using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Domain.User;
using CleanCommerce.Infrastructure.Common.Errors;
using FluentResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Common.Security
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserRepository _userRepository;
        public AuthorizeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Result<Success> AuthorizeCurrentUser<T>(IAuthorizableRequest<T> request,
                                                       List<string> requiredRoles)
        {
            //check if user exists
            if (_userRepository.GetUserById(request.UserId) is not User user)
            {
                return Result.Fail(InfrastructureErrors.Authorization.UserNotFound);
            }

            if (requiredRoles.Except(user.Roles).Any())
            {
                return Result.Fail(InfrastructureErrors.Authorization.NotAuthorized);
            }
            return Result.Ok();
        }
    }
}
