using CleanCommerce.Contracts.Product.Common;
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
        Image Image,
        Guid ParentCategoryId,
        List<Guid> ChildrenCategoryIds);
}
