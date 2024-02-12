using CleanCommerce.Application.Products.Commands.CreateProduct;
using CleanCommerce.Application.Products.Commands.UpdateProduct;
using CleanCommerce.Contracts.Product;
using CleanCommerce.Domain.Products;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductRequest, CreateProductCommand>();
            
            config.NewConfig<UpdateProductRequest, UpdateProductCommand>();

            config.NewConfig<Product, ProductResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CategoryIds, src => src.CategoryIds.Select(categoryId => categoryId.Value))
                .Map(dest => dest.PromotionIds, src => src.PromotionIds.Select(categoryId => categoryId.Value));


        }
    }
}
