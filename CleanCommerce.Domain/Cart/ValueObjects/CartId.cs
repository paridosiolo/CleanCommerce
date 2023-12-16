using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Cart.ValueObjects
{
    public sealed class CartId : ValueObject
    {
        public Guid Value { get; }
        private CartId(Guid value)
        {
            Value = value;
        }
        public static CartId Create() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
