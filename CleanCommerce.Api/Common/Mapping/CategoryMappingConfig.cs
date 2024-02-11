using CleanCommerce.Application.Categories.Commands.Create;
using CleanCommerce.Contracts.Category;
using CleanCommerce.Domain.Categories;
using Mapster;

namespace CleanCommerce.Api.Common.Mapping
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>()
                /*.Map(dest => dest.childrenCategoryIds, src => src.childrenCategoryIds)*/;

            config.NewConfig<Category, CategoryResponse>()
               .Map(dest => dest.Id, src => src.Id.Value)
               .Map(dest => dest.ParentCategoryId, src => src.Parent.Value)
               .Map(dest => dest.ChildrenCategoryIds, src => src.Children.Select(categoryId => categoryId.Value))
               .Map(dest => dest.ProductIds, src => src.ProductIds.Select(productId => productId.Value));

        }
    }
}
