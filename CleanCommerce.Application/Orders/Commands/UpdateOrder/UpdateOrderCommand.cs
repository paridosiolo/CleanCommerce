using CleanCommerce.Contracts.Common;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Enums;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Orders.Commands
{
    public record UpdateOrderCommand(
        Guid OrderId,
        Guid UserId,
        List<OrderItemCommand> OrderItems,
        decimal TotalPrice,
        string Status,
        AddressCommand ShippingAddress,
        PaymentCommand Payment
        ) : IRequest<Result<Order>>;
}
