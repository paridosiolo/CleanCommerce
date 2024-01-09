using CleanCommerce.Application.Menu.Commands.Create;
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

            if(createProductResult.IsFailed)
            {
                return Problem(createProductResult.Errors);
            }

            return Ok(_mapper.Map<ProductResponse>(createProductResult.Value));
        }
    }
}
