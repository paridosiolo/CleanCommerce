using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Common
{
    public record AddressRequest(
        string Street,
        string City,
        string State,
        string Zip
        );
}
