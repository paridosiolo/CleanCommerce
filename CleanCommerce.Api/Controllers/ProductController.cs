using CleanCommerce.Application.Products.Commands.Create;
using CleanCommerce.Application.Products.Queries.GetProduct;
using CleanCommerce.Contracts.Product;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class ProductController : ApiController
    {
        ISender _sender;
        IMapper _mapper;
        public ProductController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);

            var createProductResult = await _sender.Send(command);

            if (createProductResult.IsFailed)
            {
                return Problem(createProductResult.Errors);
            }

            return Ok(_mapper.Map<ProductResponse>(createProductResult.Value));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var query = new GetProductQuery(productId);

            var getProductResult = await _sender.Send(query);

            if(getProductResult.IsFailed)
            {
                return Problem(getProductResult.Errors);
            }

            return Ok(getProductResult.Value);
        }
    }
}
