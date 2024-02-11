using CleanCommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product? GetById(Guid productId);
        bool Delete(Product product);
        Product? Update(Guid toUpdateId, Product updated);
    }
}
