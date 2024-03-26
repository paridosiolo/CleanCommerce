using CleanCommerce.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Order
{
    public record OrderResponse(
        string OrderId,
        string UserId,
        List<OrderItemResponse> OrderItems,
        decimal TotalPrice,
        AddressResponse ShippingAddress,
        PaymentResponse Payment
        );
}
