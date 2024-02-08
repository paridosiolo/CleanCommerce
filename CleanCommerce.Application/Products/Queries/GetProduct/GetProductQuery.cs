using CleanCommerce.Domain.Products;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Products.Queries.GetProduct
{
    public record GetProductQuery(Guid ProductId)
        :IRequest<Result<Product>>;
}
