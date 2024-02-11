using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Categories.Queries.GetCategory
{
    public record GetCategoryQuery(Guid CategoryId)
        :IRequest<Result<Category>>;
}
