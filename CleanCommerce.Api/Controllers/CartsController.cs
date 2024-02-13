using CleanCommerce.Application.Carts.Commands;
using CleanCommerce.Application.Carts.Queries;
using CleanCommerce.Contracts.Cart;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class CartsController : ApiController
    {
        ISender _sender;
        IMapper _mapper;
        public CartsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCart(CreateCartRequest request)
        {
            var command = _mapper.Map<CreateCartCommand>(request);

            var createCartResult = await _sender.Send(command);

            if (createCartResult.IsFailed)
            {
                return Problem(createCartResult.Errors);
            }

            return Ok(_mapper.Map<CartResponse>(createCartResult.Value));
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCart(Guid cartId)
        {
            var query = new GetCartQuery(cartId);

            var getCartResult = await _sender.Send(query);

            if (getCartResult.IsFailed)
            {
                return Problem(getCartResult.Errors);
            }

            return Ok(_mapper.Map<CartResponse>(getCartResult.Value));
        }

        //[HttpDelete("{cartId}")]
        //public async Task<IActionResult> DeleteCart(Guid cartId)
        //{
        //    var command = new DeleteCartCommand(cartId);

        //    var deleteCartResult = await _sender.Send(command);

        //    if (deleteCartResult.IsFailed)
        //    {
        //        return Problem(deleteCartResult.Errors);
        //    }

        //    return Ok();
        //}

        //[HttpPut("update")]
        //public async Task<IActionResult> UpdateCart(UpdateCartRequest request)
        //{
        //    var command = _mapper.Map<UpdateCartCommand>(request);

        //    var updateCartResult = await _sender.Send(command);

        //    if (updateCartResult.IsFailed)
        //    {
        //        return Problem(updateCartResult.Errors);
        //    }

        //    return Ok(_mapper.Map<CartResponse>(updateCartResult.Value));
        //}
    }
}
