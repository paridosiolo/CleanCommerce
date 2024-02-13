using CleanCommerce.Domain.Products;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Products.Commands
{
    public record DeleteProductCommand(Guid ProductId)
        : IRequest<Result<bool>>;
}
