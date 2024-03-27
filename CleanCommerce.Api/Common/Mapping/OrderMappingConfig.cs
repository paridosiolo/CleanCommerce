using CleanCommerce.Application.Orders.Commands;
using CleanCommerce.Application.Orders.Commands.CreateOrder;
using CleanCommerce.Contracts.Common;
using CleanCommerce.Contracts.Order;
using CleanCommerce.Domain.Orders;
using CleanCommerce.Domain.Orders.Entities;
using CleanCommerce.Domain.Orders.Enums;
using FluentResults;
using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CleanCommerce.Api.Common.Mapping
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateOrderRequest, CreateOrderCommand>();

            config.NewConfig<UpdateOrderRequest, UpdateOrderCommand>();

            config.NewConfig<Order, OrderResponse>()
                .Map(dest => dest.OrderId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.Status, src => src.Status.ToString());

            config.NewConfig<OrderItem, OrderItemResponse>()
                .Map(dest => dest.OrderItemId, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value);
        }

    }
}
