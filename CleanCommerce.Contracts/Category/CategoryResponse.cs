using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Category
{
    public record CategoryResponse(
        string Id,
        string Name,
        string Description,
        ImageResponse Image,
        string ParentCategoryId,
        List<string> ChildrenCategoryIds,
        List<string> ProductIds);

    public record ImageResponse(string Url);
}
