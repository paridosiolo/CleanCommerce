using CleanCommerce.Contracts.Product.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Product
{
        public record UpdateProductRequest(
            Guid ProductId,
            string Name,
            string Description,
            float Price,
            int Stock,
            List<Image> Images);
}
