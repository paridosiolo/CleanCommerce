using CleanCommerce.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Orders.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public string Street { get;}
        public string City { get;}
        public string State { get;}
        public string Zip { get;}

        private Address(string street,
                                string city,
                                string state,
                                string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public static Address Create(string street,
                                string city,
                                string state,
                                string zip)
        {
            return new Address(street,
                                       city,
                                       state,
                                       zip);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] {Street, City, State, Zip};
        }
    }
}
