using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Application.Common.Interfaces.Authentication;
using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.User;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if user exists
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                return Result.Fail(ApplicationErrors.Authentication.DuplicateEmail);
            }

            //create user
            var user = User.Create(request.FirstName,
                                   request.LastName,
                                   request.Email,
                                   request.Password,
                                   request.Role);

            //save user
            _userRepository.Add(user);

            //generate token
            var token = _jwtTokenGenerator.GenerateJwtToken(user.Id.Value, user.FirstName, user.LastName);

            return new AuthenticationResult(user, token);
        }
    }
}
