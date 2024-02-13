using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Contracts.Common;

namespace CleanCommerce.Contracts.Product
{
    public record CreateProductRequest(
        string Name,
        string Description,
        float Price,
        int Stock,
        List<ImageRequest> Images);

}
