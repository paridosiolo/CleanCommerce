using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Orders;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid orderId);
        bool Delete(Order order);
        //Order? Update(Guid toUpdateId,
        //                string name,
        //                string description,
        //                float price,
        //                int stock,
        //                List<Image> images);
    }
}
