using CleanCommerce.Application.Carts.Commands;
using CleanCommerce.Application.Carts.Common;
using CleanCommerce.Contracts.Cart;
using CleanCommerce.Contracts.Common;
using CleanCommerce.Domain.Carts;
using CleanCommerce.Domain.Carts.Entities;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class CartMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCartRequest, CreateCartCommand>();

            config.NewConfig<UpdateCartRequest, UpdateCartCommand>();
            config.NewConfig<CartItemRequest, CartItemCommand>();

            config.NewConfig<Cart, CartResponse>()
                .Map(dest => dest.CartId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value);

            config.NewConfig<CartItem, CartItemResponse>()
                .Map(dest => dest.CartItemId, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value);
        }
    }
}
