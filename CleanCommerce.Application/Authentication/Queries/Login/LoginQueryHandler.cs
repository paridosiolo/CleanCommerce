using CleanCommerce.Application.Authentication.Commands.Register;
using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Application.Common.Interfaces.Authentication;
using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Entities;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Result.Fail(ApplicationErrors.Authentication.UserNotFound);
            }

            //check if password is correct
            if (user.Password != query.Password)
            {
                return Result.Fail(ApplicationErrors.Authentication.InvalidPassword);
            }

            //generate token
            var token = _jwtTokenGenerator.GenerateJwtToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(user, token);
        }

    }
}
