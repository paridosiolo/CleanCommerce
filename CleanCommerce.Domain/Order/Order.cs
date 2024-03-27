using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Orders.ValueObjects;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Orders.Enums;

namespace CleanCommerce.Domain.Orders
{
    public sealed class Order : AggregateRoot<OrderId>
    {
        private readonly List<OrderItem> _orderitems = new();
        public UserId UserId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Address ShippingAddress { get; private set; }
        public DateTime Created { get;}
        public DateTime Updated { get; private set; }
        public OrderStatus Status { get; private set; }
        public Payment Payment { get; private set; }
        public IReadOnlyList<OrderItem> OrderItems => _orderitems.AsReadOnly();

        private Order(OrderId id,
                      UserId userId,
                      List<OrderItem> orderitems,
                      decimal totalPrice,
                      Address shippingAddress,
                      DateTime created,
                      DateTime updated,
                      OrderStatus status,
                      Payment payment) : base(id)
        {
            UserId = userId;
            _orderitems = orderitems;
            TotalPrice = totalPrice;
            ShippingAddress = shippingAddress;
            Created = created;
            Updated = updated;
            Status = status;
            Payment = payment;
        }

        public static Order Create(UserId userId,
                                   List<OrderItem> orderItems,
                                   decimal totalPrice,
                                   Address shippingAddress,
                                   Payment payment)
        {
            return new Order(OrderId.Create(),
                             userId,
                             orderItems,
                             totalPrice,
                             shippingAddress,
                             DateTime.UtcNow,
                             DateTime.UtcNow,
                             OrderStatus.Created,
                             payment);
        }

        public Order Update(Guid userId,
                            List<OrderItem> orderItems,
                            decimal totalPrice,
                            OrderStatus status,
                            Address shippingAddress,
                            Payment payment)
        {
            this.Updated = DateTime.UtcNow;

            this.UserId = UserId.Create(userId);
            this.TotalPrice = totalPrice;
            this.Status = status;
            this.ShippingAddress = shippingAddress; 
            this.Payment = payment;

            this._orderitems.Clear();
            this._orderitems.AddRange(orderItems);

            return this;
        }
    } 
}
