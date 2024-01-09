using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Product
{
    public record CreateProductRequest(
        string Name,
        string Description,
        float Price,
        int Stock,
        List<Image> Images);

    public record Image(string Url);
}
