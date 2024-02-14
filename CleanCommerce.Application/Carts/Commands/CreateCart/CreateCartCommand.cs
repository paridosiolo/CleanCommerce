using CleanCommerce.Application.Carts.Common;
using CleanCommerce.Domain.Carts;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Commands
{
    public record CreateCartCommand(Guid UserId) : IRequest<Result<Cart>>;
}
