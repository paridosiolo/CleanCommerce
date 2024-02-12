using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Categories;
using CleanCommerce.Application.Common.Errors;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace CleanCommerce.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if category exists
            if (_categoryRepository.GetById(request.CategoryId) is not Category category)
            {
                return Result.Fail(ApplicationErrors.Categories.CategoryNotFound(
                    categoryId: request.CategoryId.ToString()));
            }

            if(!_categoryRepository.Delete(category))
            {
                return Result.Fail(ApplicationErrors.Categories.CouldNotDelete(
                    categoryId: request.CategoryId.ToString()));
            }

            return Result.Ok();
        }
    }
}
