using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Categories.ValueObjects;

namespace CleanCommerce.Application.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Category>>
    {
        private ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Create category
            var category = Category.Create(
                name: request.Name,
                description: request.Description,
                image: Image.Create(request.Image.Url),
                parent: CategoryId.Create(request.ParentCategoryId),
                children: request.ChildrenCategoryIds.ConvertAll(guid => CategoryId.Create(guid)));

            //persist category
            _categoryRepository.Add(category);

            //return category
            return category;
        }
    }
}
