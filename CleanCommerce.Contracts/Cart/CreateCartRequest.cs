using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Contracts.Common;

namespace CleanCommerce.Contracts.Cart
{
    public record CreateCartRequest(Guid UserId);
}
