using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Application.Common.Errors;
using CleanCommerce.Domain.User;
using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Categories.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result<Category>>
    {
        private ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //check if category exists
            if (_categoryRepository.GetById(request.CategoryId) is not Category category)
            {
                return Result.Fail(ApplicationErrors.Categories.CategoryNotFound(
                    categoryId: request.CategoryId.ToString()));
            }
            return category;
        }
    }
}
