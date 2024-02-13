using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Carts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Persistence
{
    public class CartRepository : ICartRepository
    {
        private static List<Cart> _carts = new(); 
        public void Add(Cart cart)
        {
            _carts.Add(cart);
        }

        public Cart? GetById(Guid cartId)
        {
            return _carts.FirstOrDefault(p => p.Id.Value == cartId);
        }

        public bool Delete(Cart cart)
        {
            return _carts.Remove(cart);
        }
        public Cart? Update(Guid toUpdateId, Cart updated) 
        {
            var toUpdate = GetById(toUpdateId);
            //return toUpdate?.Update(updated.Name,
            //                        updated.Description,
            //                        updated.Image,
            //                        updated.Parent,
            //                        updated.Children.ToList());
            throw new NotImplementedException();
        }
    }
}
