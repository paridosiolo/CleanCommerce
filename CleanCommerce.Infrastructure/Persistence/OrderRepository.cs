using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Orders.Enums;
using CleanCommerce.Domain.Orders.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new(); 
        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order? GetById(Guid orderId)
        {
            return _orders.FirstOrDefault(p => p.Id.Value == orderId);
        }

        public bool Delete(Order order)
        {
            return _orders.Remove(order);
        }

        public Order? Update(Guid orderId,
                             Guid userId,
                             List<OrderItem> orderItems,
                             decimal totalPrice,
                             OrderStatus status,
                             Address shippingAddress,
                             Payment payment)
        {
            var toUpdate = GetById(orderId);
            return toUpdate?.Update(userId,
                                    orderItems,
                                    totalPrice,
                                    status,
                                    shippingAddress,
                                    payment);
        }
    }
}
