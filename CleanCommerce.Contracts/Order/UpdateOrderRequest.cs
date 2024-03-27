using CleanCommerce.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Order
{
    public record UpdateOrderRequest(
        Guid OrderId,
        Guid UserId,
        List<OrderItemRequest> OrderItems,
        decimal TotalPrice,
        string Status,
        AddressRequest ShippingAddress,
        PaymentRequest Payment
        );
}
