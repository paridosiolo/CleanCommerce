using CleanCommerce.Application.Orders.Commands.CreateOrder;
using CleanCommerce.Contracts.Order;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ApiController
    {
        ISender _sender;
        IMapper _mapper;
        public OrdersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);

            var createOrderResult = await _sender.Send(command);

            if(createOrderResult.IsFailed)
            {
                return Problem(createOrderResult.Errors);
            }

            return Ok(_mapper.Map<OrderResponse>(createOrderResult.Value));
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(new string[] { "caio", "mario"});
        }
    }
}
