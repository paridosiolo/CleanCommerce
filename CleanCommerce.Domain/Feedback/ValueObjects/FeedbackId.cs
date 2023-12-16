using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCommerce.Domain.Common.Models;

namespace CleanCommerce.Domain.Feedback.ValueObjects
{
    public sealed class FeedbackId : ValueObject
    {
        public Guid Value { get; }
        private FeedbackId(Guid value)
        {
            Value = value;
        }
        public static FeedbackId Create() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
