using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Order.ValueObjects;
using CleanCommerce.Domain.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Order.Enums;

namespace CleanCommerce.Domain.Order
{
    public sealed class Order : AggregateRoot<OrderId>
    {
        private readonly List<UserId> _userIds = new();
        private readonly List<OrderItem> _orderitems = new();
        public decimal TotalPrice { get; private set; }
        public Address ShippingAddress { get; private set; }
        public DateTime Created { get;}
        public DateTime Updated { get; private set; }
        public OrderStatus Status { get; private set; }
        public Payment Payment { get; private set; }
        public IReadOnlyList<UserId> UserIds => _userIds.AsReadOnly();
        public IReadOnlyList<OrderItem> OrderItems => _orderitems.AsReadOnly();

        private Order(OrderId id,
                      List<OrderItem> orderitems,
                      decimal totalPrice,
                      Address shippingAddress,
                      DateTime created,
                      DateTime updated,
                      OrderStatus status,
                      Payment payment) : base(id)
        {
            _orderitems = orderitems;
            TotalPrice = totalPrice;
            ShippingAddress = shippingAddress;
            Created = created;
            Updated = updated;
            Status = status;
            Payment = payment;
        }

        public static Order Create(List<OrderItem> orderItems,
                                   decimal totalprice,
                                   Address shippingAddress,
                                   OrderStatus status,
                                   Payment payment)
        {
            return new Order(OrderId.Create(),
                             orderItems,
                             totalprice,
                             shippingAddress,
                             DateTime.UtcNow,
                             DateTime.UtcNow,
                             status,
                             payment);
        }
    } 
}
