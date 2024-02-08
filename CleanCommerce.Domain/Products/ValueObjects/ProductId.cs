using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Products.ValueObjects
{
    public sealed class ProductId : ValueObject
    {
        public Guid Value { get; }
        private ProductId(Guid value)
        {
            Value = value;
        }
        public static ProductId Create() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
