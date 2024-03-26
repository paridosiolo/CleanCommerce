using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Common
{
    public record PaymentRequest(
        string CardNumber,
        DateTime ExpirationDate,
        string SecurityCode,
        string Currency,
        AddressRequest BillingAddress
        );
}
