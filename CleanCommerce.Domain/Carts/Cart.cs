using CleanCommerce.Domain.Carts.Entities;
using CleanCommerce.Domain.Carts.ValueObjects;
using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Carts
{
    public sealed class Cart : AggregateRoot<CartId>
    {
        private readonly List<CartItem> _cartItems = new();
        public UserId UserId { get;}
        public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();

        private Cart(CartId id, UserId userId) : base(id)
        {
            UserId = userId;
        }

        public static Cart Create(UserId userId)
        {
            return new Cart(CartId.Create(), userId);
        }
    }
}
