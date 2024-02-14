using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new(); 
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product? GetById(Guid productId)
        {
            return _products.FirstOrDefault(p => p.Id.Value == productId);
        }

        public bool Delete(Product product)
        {
            return _products.Remove(product);
        }
        public Product? Update(Guid toUpdateId,
                               string name,
                               string description,
                               float price,
                               int stock,
                               List<Image> images) 
        {
            var toUpdate = GetById(toUpdateId);
            return toUpdate?.Update(name,
                                    description,
                                    price,
                                    stock,
                                    images.ToList());
        }
    }
}
