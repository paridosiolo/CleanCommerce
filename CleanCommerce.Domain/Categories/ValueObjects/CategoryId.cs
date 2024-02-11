using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Categories.ValueObjects
{
    public sealed class CategoryId : ValueObject
    {
        public Guid Value { get; }
        private CategoryId(Guid value)
        {
            Value = value;
        }
        public static CategoryId Create() => new(Guid.NewGuid());
        public static CategoryId Create(Guid guid) => new(guid);
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
