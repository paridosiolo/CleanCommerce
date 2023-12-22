using CleanCommerce.Application.Authentication.Common;
using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Application.Common.Security.Role;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email,
                             string Password) : IRequest<Result<AuthenticationResult>>;
}
