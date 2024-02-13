using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Products;
using CleanCommerce.Application.Common.Errors;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace CleanCommerce.Application.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if product exists
            if (_productRepository.GetById(request.ProductId) is not Product product)
            {
                return Result.Fail(ApplicationErrors.Products.ProductNotFound(
                    productId: request.ProductId.ToString()));
            }

            if(!_productRepository.Delete(product))
            {
                return Result.Fail(ApplicationErrors.Products.CouldNotDelete(
                    productId: request.ProductId.ToString()));
            }

            return Result.Ok();
        }
    }
}
