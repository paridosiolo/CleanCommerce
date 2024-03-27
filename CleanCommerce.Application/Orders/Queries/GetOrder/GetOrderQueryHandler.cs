using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Orders;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Check if order exist
            if(_orderRepository.GetById(request.OrderId) is not Order order)
            {
                return Result.Fail(ApplicationErrors.Orders.OrderNotFound(
                    orderId: request.OrderId.ToString()));
            }

            return order;
        }
    }
}
