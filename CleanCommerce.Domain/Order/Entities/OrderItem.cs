using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Order.ValueObjects;
using CleanCommerce.Domain.Product.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Order.Entities
{
    public sealed class OrderItem : Entity<OrderItemId>
    {
        public ProductId ProductId { get; }
        public int Amount { get; }

        private OrderItem(OrderItemId orderItemId,
                          ProductId productId,
                          int amount) : base(orderItemId)
        {
            ProductId = productId;
            Amount = amount;
        }

        public static OrderItem Create(ProductId productId,
                                       int amount)
        {
            return new OrderItem(OrderItemId.Create(),
                                 productId,
                                 amount);
        }
    }
}
