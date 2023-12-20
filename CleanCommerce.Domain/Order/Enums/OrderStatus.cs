using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Order.Enums
{
    public enum OrderStatus
    {
        Created,
        WaitingPayment,
        Paid,
        Shipped,
        Delivered
    }
}
