using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Orders;
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
    }
}
