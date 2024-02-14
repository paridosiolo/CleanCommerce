using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Carts.Entities;
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
        public Cart? Update(Guid toUpdateId, List<CartItem> cartItems) 
        {
            var toUpdate = GetById(toUpdateId);

            return toUpdate?.Update(cartItems);
        }
    }
}
