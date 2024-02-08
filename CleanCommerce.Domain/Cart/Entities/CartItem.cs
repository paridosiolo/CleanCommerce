using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Cart.ValueObjects;
using CleanCommerce.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Cart.Entities
{
    public sealed class CartItem : Entity<CartItemId>
    {
        public ProductId ProductId { get; }
        public int Amount { get; }

        private CartItem(CartItemId cartItemId,
                          ProductId productId,
                          int amount) : base(cartItemId)
        {
            ProductId = productId;
            Amount = amount;
        }

        public static CartItem Create(ProductId productId,
                                       int amount)
        {
            return new CartItem(CartItemId.Create(),
                                 productId,
                                 amount);
        }
    }
}
