using CleanCommerce.Application.Menu.Commands.Create;
using CleanCommerce.Contracts.Product;
using CleanCommerce.Domain.Product;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductCommand, CreateProductRequest>();
            config.NewConfig<Product, ProductResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CategoryIds, src => src.CategoryIds.Select(categoryId => categoryId.Value))
                .Map(dest => dest.PromotionIds, src => src.PromotionIds.Select(categoryId => categoryId.Value));

        }
    }
}
