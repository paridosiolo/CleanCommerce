using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Orders.Enums
{
    public enum OrderStatus
    {
        Created,
        Pending,
        Processing,
        Shipped,
        Delivered
    }
}
