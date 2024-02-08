using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Products;
using CleanCommerce.Domain.User;
using FluentResults;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<Product>>
    {
        private IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //check if product exists
            if (_productRepository.GetById(request.ProductId) is not Product product)
            {
                return Result.Fail(ApplicationErrors.Products.ProductNotFound(
                    productId:request.ProductId.ToString()));
            }
            return product;
        }
    }
}
