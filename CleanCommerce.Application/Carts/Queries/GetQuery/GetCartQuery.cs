using CleanCommerce.Domain.Carts;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Carts.Queries
{
    public record GetCartQuery(Guid CartId)
        : IRequest<Result<Cart>>;
}
