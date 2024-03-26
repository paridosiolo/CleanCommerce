using CleanCommerce.Contracts.Common;
using CleanCommerce.Domain.Orders;
using FluentResults;
using MediatR;

namespace CleanCommerce.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(
        Guid UserId,
        List<OrderItemCommand> OrderItems,
        decimal TotalPrice,
        AddressCommand ShippingAddress,
        PaymentCommand Payment
        ) :IRequest<Result<Order>>;
}
