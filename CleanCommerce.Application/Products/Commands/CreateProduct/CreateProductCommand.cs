using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Application.Products.Common;
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
    public record CreateProductCommand(
        string Name,
        string Description,
        float Price,
        int Stock,
        List<ImageCommand> Images) : IRequest<Result<Product>>;
}
