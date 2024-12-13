using CleanCommerce.Application.Products.Commands;
using CleanCommerce.Application.Products.Common;
using CleanCommerce.Application.Products.Queries;
using CleanCommerce.Contracts.Product;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class ProductsController : ApiController
    {
        ISender _sender;
        IMapper _mapper;
        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(Guid userId, CreateProductRequest request)
        {
            var command = new CreateProductCommand(
                userId,
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Images.ConvertAll(x => new ImageCommand(x.Url))
            );

            var createProductResult = await _sender.Send(command);

            if (createProductResult.IsFailed)
            {
                return Problem(createProductResult.Errors);
            }

            return Ok(_mapper.Map<ProductResponse>(createProductResult.Value));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var query = new GetProductQuery(productId);

            var getProductResult = await _sender.Send(query);

            if(getProductResult.IsFailed)
            {
                return Problem(getProductResult.Errors);
            }

            return Ok(_mapper.Map<ProductResponse>(getProductResult.Value));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var command = new DeleteProductCommand(productId);

            var deleteProductResult = await _sender.Send(command);

            if(deleteProductResult.IsFailed)
            {
                return Problem(deleteProductResult.Errors);
            }

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            var command = _mapper.Map<UpdateProductCommand>(request);

            var updateProductResult = await _sender.Send(command);

            if(updateProductResult.IsFailed) 
            {
                return Problem(updateProductResult.Errors);
            }

            return Ok(_mapper.Map<ProductResponse>(updateProductResult.Value));
        }
    }
}
