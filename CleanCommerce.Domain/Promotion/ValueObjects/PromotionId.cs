using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Promotion.ValueObjects
{
    public sealed class PromotionId : ValueObject
    {
        public Guid Value { get; }
        private PromotionId(Guid value)
        {
            Value = value;
        }
        public static PromotionId Create() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
