using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Carts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        Cart? GetById(Guid cartId);
        bool Delete(Cart cart);
        Cart? Update(Guid toUpdateId, List<CartItem> cartItems);
    }
}
