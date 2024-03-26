using CleanCommerce.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Order
{
    public record CreateOrderRequest(
        Guid UserId,
        List<OrderItemRequest> OrderItems,
        decimal TotalPrice,
        AddressRequest ShippingAddress,
        PaymentRequest Payment
        );
}
