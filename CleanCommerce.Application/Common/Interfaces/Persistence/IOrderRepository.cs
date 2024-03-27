using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Orders.Enums;
using CleanCommerce.Domain.Orders.ValueObjects;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid orderId);
        bool Delete(Order order);
        Order? Update(Guid orderId,
                      Guid userId,
                      List<OrderItem> orderItems,
                      decimal totalPrice,
                      OrderStatus status,
                      Address shippingAddress,
                      Payment payment);
    }
}
