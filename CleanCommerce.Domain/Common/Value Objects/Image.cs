using CleanCommerce.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Common.Value_Objects
{
    public sealed class Image : ValueObject
    {
        public string Url { get; private set; }
        private Image(string url)
        {
            Url = url;
        }

        public static Image Create(string url) => new (url);
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Url;
        }
    }
}
