using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Carts.ValueObjects
{
    public sealed class CartItemId : ValueObject
    {
        public Guid Value { get; }
        private CartItemId(Guid value)
        {
            Value = value;
        }
        public static CartItemId Create() => new(Guid.NewGuid());
        public static CartItemId Create(Guid guid) => new(guid);
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
