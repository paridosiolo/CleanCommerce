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
    public record DeleteCategoryCommand(Guid CategoryId)
        : IRequest<Result<bool>>;
}
