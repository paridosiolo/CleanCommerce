using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Application.Common.Errors;
using FluentResults;
using MediatR;

namespace CleanCommerce.Application.Orders.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<bool>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if order exists
            if (_orderRepository.GetById(request.OrderId) is not Order order)
            {
                return Result.Fail(ApplicationErrors.Orders.OrderNotFound(
                    orderId: request.OrderId.ToString()));
            }

            if(!_orderRepository.Delete(order))
            {
                return Result.Fail(ApplicationErrors.Orders.CouldNotDelete(
                    orderId: request.OrderId.ToString()));
            }

            return Result.Ok();
        }
    }
}
