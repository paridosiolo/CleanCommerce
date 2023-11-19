using CleanCommerce.Application.Authentication.Common;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName,
                                  string LastName,
                                  string Email,
                                  string Password) : IRequest<Result<AuthenticationResult>>;
}
