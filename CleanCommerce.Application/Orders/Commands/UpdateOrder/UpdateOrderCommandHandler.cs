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
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Products.ValueObjects;
using CleanCommerce.Domain.Orders.ValueObjects;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Orders.Enums;

namespace CleanCommerce.Application.Orders.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Order>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            OrderStatus parsedStatus;
            Enum.TryParse(request.Status, out parsedStatus);

                var updatedOrder = _orderRepository.Update(
                    orderId: request.OrderId,
                    userId: request.UserId,
                    orderItems: request.OrderItems.ConvertAll(i => OrderItem.Create(ProductId.Create(i.ProductId), i.Amount)),
                    status: parsedStatus,
                    totalPrice: request.TotalPrice,
                    shippingAddress: Address.Create(request.ShippingAddress.Street,
                                                    request.ShippingAddress.City,
                                                    request.ShippingAddress.State,
                                                    request.ShippingAddress.Zip),

                    payment: Payment.Create(request.Payment.CardNumber,
                                            request.Payment.ExpirationDate,
                                            request.Payment.SecurityCode,
                                            request.Payment.Currency,
                                            Address.Create(request.Payment.BillingAddress.Street,
                                                           request.Payment.BillingAddress.City,
                                                           request.Payment.BillingAddress.State,
                                                           request.Payment.BillingAddress.Zip)));

                if (updatedOrder == null)
                {
                    return Result.Fail(ApplicationErrors.Orders.OrderNotFound(
                        orderId: request.OrderId.ToString()));
                }

                return updatedOrder;
        }
    }
}
