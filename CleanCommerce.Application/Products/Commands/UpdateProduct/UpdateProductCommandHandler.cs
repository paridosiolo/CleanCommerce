using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Products;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.ValueObjects;

namespace CleanCommerce.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Product>>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var updatedProduct = Product.Create(
                name: request.Name,
                description: request.Description,
                price: request.Price,
                stock: request.Stock,
                images: request.Images.ConvertAll(i => Image.Create(i.Url)));

            updatedProduct = _productRepository.Update(request.ProductId, updatedProduct);

            if(updatedProduct == null) 
            {
                return Result.Fail(ApplicationErrors.Products.ProductNotFound(
                    productId: request.ProductId.ToString()));
            }

            return updatedProduct;
        }
    }
}
