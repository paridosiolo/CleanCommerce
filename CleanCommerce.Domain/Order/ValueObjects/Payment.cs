using CleanCommerce.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Orders.ValueObjects
{
    public sealed class Payment : ValueObject
    {
        public string CardNumber { get; }
        public DateTime ExpirationDate { get; }
        public string SecurityCode { get; }
        public string Currency { get; }
        public Address BillingAddress { get; }

        private Payment(string cardNumber,
                        DateTime expirationDate,
                        string securityCode,
                        string currency,
                        Address billingAddress) 
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            SecurityCode = securityCode;
            Currency = currency;
            BillingAddress = billingAddress;
        }

        public static Payment Create(string cardNumber,
                                     DateTime expirationDate,
                                     string securityCode,
                                     string currency,
                                     Address billingAddress)
        {
            return new Payment(cardNumber,
                               expirationDate,
                               securityCode,
                               currency,
                               billingAddress);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[]
            {
                CardNumber,
                ExpirationDate,
                SecurityCode,
                Currency,
                BillingAddress
            };
        }
    }
}
