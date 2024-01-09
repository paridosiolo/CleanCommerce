using CleanCommerce.Domain.Category.ValueObjects;
using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Feedback.ValueObjects;
using CleanCommerce.Domain.Product.ValueObjects;
using CleanCommerce.Domain.Promotion.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Product
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        private readonly List<Image> _images = new();
        private readonly List<CategoryId> _categoryIds = new();
        private readonly List<PromotionId> _promotionIds = new();
        private readonly List<FeedbackId> _feedbackIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Price { get; private set; }
        public int Stock { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? Updated { get; private set; }
        public IReadOnlyList<Image> Images => _images.AsReadOnly();
        public IReadOnlyList<CategoryId> CategoryIds => _categoryIds.AsReadOnly();
        public IReadOnlyList<PromotionId> PromotionIds => _promotionIds.AsReadOnly();
        public IReadOnlyList<FeedbackId> FeedbackIds => _feedbackIds.AsReadOnly();

        public Product(ProductId id,
                       string name,
                       string description,
                       float price,
                       int stock,
                       DateTime created,
                       DateTime updated,
                       List<Image> images) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Created = created;
            Updated = updated;
            _images = images;
        }

        public static Product Create(string name,
                                     string description,
                                     float price,
                                     int stock,
                                     List<Image> images)
        {
            var product = new Product(ProductId.Create(),
                                      name,
                                      description,
                                      price,
                                      stock,
                                      DateTime.UtcNow,
                                      DateTime.UtcNow,
                                      images);
            return product;
        }

    }
}
