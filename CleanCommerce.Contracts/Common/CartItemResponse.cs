using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Common
{
    public record CartItemResponse(Guid CartItemId,
                           Guid ProductId,
                           int Amount);
}
