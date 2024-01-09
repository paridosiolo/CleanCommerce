using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Product;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Menu.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Product>>
    {
        private IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Create product
            var product = Product.Create(
                name: request.Name,
                description: request.Description,
                price: request.Price,
                stock: request.Stock,
                images: request.Images.ConvertAll(i => Image.Create(i.Url)));

            //persist Product
            _productRepository.Add(product);

            //return product
            return product;
        }
    }
}
