using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Orders.ValueObjects;
using CleanCommerce.Domain.Products.ValueObjects;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Order>>
    {
        private IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Create Order
            var order = Order.Create(
                userId: UserId.Create(request.UserId),
                orderItems: request.OrderItems.ConvertAll(i => OrderItem.Create(ProductId.Create(i.ProductId), i.Amount)),
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
                                                       request.Payment.BillingAddress.Zip))
                );
            //Persist Order
            _orderRepository.Add( order );

            //Return Order
            return order;
        }
    }
}
