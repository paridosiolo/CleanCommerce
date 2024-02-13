using CleanCommerce.Application.Categories.Common;
using CleanCommerce.Application.Common.Security.Request;
using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Categories.Commands
{
    public record CreateCategoryCommand(
        string Name,
        string Description,
        ImageCommand Image,
        Guid ParentCategoryId,
        List<Guid> ChildrenCategoryIds) : IRequest<Result<Category>>;
}
