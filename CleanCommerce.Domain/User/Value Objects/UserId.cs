using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Common.Models.User.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; set; }
        private UserId(Guid value)
        {
            Value = value;
        }
        public static UserId Create() => new (Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
