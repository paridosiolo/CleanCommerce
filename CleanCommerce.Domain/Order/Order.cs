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
        public decimal TotalPrice { get;}
        public Address ShippingAddress { get;}
        public DateTime Created { get;}
        public OrderStatus Status { get;}
        public Payment Payment { get;}

        private Order(OrderId id,
                      List<OrderItem> orderitems,
                      decimal totalPrice,
                      Address shippingAddress,
                      DateTime created,
                      OrderStatus status,
                      Payment payment) : base(id)
        {
            _orderitems = orderitems;
            TotalPrice = totalPrice;
            ShippingAddress = shippingAddress;
            Created = created;
            Status = status;
            Payment = payment;
        }

        public static Order Create(List<OrderItem> orderItems,
                                   decimal totalprice,
                                   Address shippingAddress,
                                   DateTime created,
                                   OrderStatus status,
                                   Payment payment)
        {
            return new Order(OrderId.Create(),
                             orderItems,
                             totalprice,
                             shippingAddress,
                             created,
                             status,
                             payment);
        }
    } 
}
