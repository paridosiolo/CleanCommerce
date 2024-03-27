using CleanCommerce.Application.Orders.Commands;
using CleanCommerce.Application.Orders.Commands.CreateOrder;
using CleanCommerce.Application.Orders.Queries.GetOrder;
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

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var query = new GetOrderQuery(orderId);

            var getOrderResult = await _sender.Send(query);

            if(getOrderResult.IsFailed)
            {
                return Problem(getOrderResult.Errors);
            }

            return Ok(_mapper.Map<OrderResponse>(getOrderResult.Value));
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var command = new DeleteOrderCommand(orderId);

            var deleteOrderResult = await _sender.Send(command);

            if (deleteOrderResult.IsFailed)
            {
                return Problem(deleteOrderResult.Errors);
            }

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderCommand>(request);

            var updateOrderResult = await _sender.Send(command);

            if (updateOrderResult.IsFailed)
            {
                return Problem(updateOrderResult.Errors);
            }

            return Ok(_mapper.Map<OrderResponse>(updateOrderResult.Value));
        }
    }
}
