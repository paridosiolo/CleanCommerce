using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Application.Common.Security.Role;
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
    [Authorize(Roles = Role.Admin)]
    public record CreateProductCommand(
        Guid UserId,
        string Name,
        string Description,
        float Price,
        int Stock,
        List<ImageCommand> Images) : IAuthorizableRequest<Result<Product>>;
}
