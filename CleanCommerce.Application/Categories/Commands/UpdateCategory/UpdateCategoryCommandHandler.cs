using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Categories.ValueObjects;

namespace CleanCommerce.Application.Categories.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var updatedCategory = Category.Create(
                name: request.Name,
                description: request.Description,
                image: Image.Create(request.Image.Url),
                parent: CategoryId.Create(request.ParentCategoryId),
                children: request.ChildrenCategoryIds.ConvertAll(guid => CategoryId.Create(guid)));

            updatedCategory = _categoryRepository.Update(request.CategoryId, updatedCategory);

            if(updatedCategory == null) 
            {
                return Result.Fail(ApplicationErrors.Categories.CategoryNotFound(
                    categoryId: request.CategoryId.ToString()));
            }

            return updatedCategory;
        }
    }
}
