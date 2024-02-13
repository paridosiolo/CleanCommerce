using CleanCommerce.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Category
{
    public record CreateCategoryRequest(
        string Name,
        string Description,
        ImageRequest Image,
        Guid ParentCategoryId,
        List<Guid> ChildrenCategoryIds);
}
