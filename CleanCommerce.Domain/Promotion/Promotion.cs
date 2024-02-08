using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Products.ValueObjects;
using CleanCommerce.Domain.Promotion.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Promotion
{
    public sealed class Promotion : AggregateRoot<PromotionId>
    {
        private readonly List<ProductId> _productIds = new();
        public string Name { get; }
        public string Description { get; }
        public bool IsPercentage { get; }
        public decimal Discount { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

        private Promotion(PromotionId id,
                         string name,
                         string description,
                         bool isPercentage,
                         decimal discount,
                         DateTime startDate,
                         DateTime endDate) : base(id)
        {
            Name = name;
            Description = description;
            IsPercentage = isPercentage;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static Promotion Create(string name,
                                       string description,
                                       bool isPercentage,
                                       decimal discount,
                                       DateTime startDate,
                                       DateTime endDate)
        {
            return new Promotion(PromotionId.Create(),
                                 name,
                                 description,
                                 isPercentage,
                                 discount,
                                 startDate,
                                 endDate);
        }
    }
}
