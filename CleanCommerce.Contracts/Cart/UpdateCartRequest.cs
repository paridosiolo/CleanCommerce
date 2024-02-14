using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Contracts.Common;

namespace CleanCommerce.Contracts.Cart
{
    public record UpdateCartRequest(Guid CartId,
                                    Guid UserId,
                                    List<CartItemRequest> CartItems);
}
