using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Order.ValueObjects
{
    public sealed class OrderItemId : ValueObject
    {
        public Guid Value { get; }
        private OrderItemId(Guid value)
        {
            Value = value;
        }
        public static OrderItemId Create() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
