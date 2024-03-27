using CleanCommerce.Application.Orders.Commands;
using CleanCommerce.Application.Orders.Commands.CreateOrder;
using CleanCommerce.Contracts.Common;
using CleanCommerce.Contracts.Order;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Entities;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateOrderRequest, CreateOrderCommand>();


            config.NewConfig<Order, OrderResponse>()
                .Map(dest => dest.OrderId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value);

            config.NewConfig<OrderItem, OrderItemResponse>()
                .Map(dest => dest.OrderItemId, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value);
            
            //config.NewConfig<UpdateOrderRequest, UpdateOrderCommand>();
        }
    }
}
