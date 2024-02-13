﻿using CleanCommerce.Domain.Categories;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Categories.Commands
{
    public record UpdateCategoryCommand(
        Guid CategoryId,
        string Name,
        string Description,
        ImageCommand Image,
        Guid ParentCategoryId,
        List<Guid> ChildrenCategoryIds) : IRequest<Result<Category>>;

    public record ImageCommand(string Url);
}
