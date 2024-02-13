using CleanCommerce.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Contracts.Product
{
    public record ProductResponse(
        string Id,
        string Name,
        string Description,
        List<ImageResponse> Images,
        float Price,
        int Stock,
        DateTime Created,
        DateTime Updated,
        List<string> CategoryIds,
        List<string> PromotionIds);
}
