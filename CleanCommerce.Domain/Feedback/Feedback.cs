using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Feedback.ValueObjects;
using CleanCommerce.Domain.Orders.ValueObjects;
using CleanCommerce.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Feedback
{
    public sealed class Feedback : AggregateRoot<FeedbackId>
    {
        public short Rating { get; }
        public string Text { get; } 
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public ProductId ProductId { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }

        private Feedback(FeedbackId id,
                        short rating,
                        string text,
                        DateTime created,
                        DateTime updated,
                        ProductId productId,
                        UserId userId,
                        OrderId orderId) : base(id)
        {
            Rating = rating;
            Text = text;
            Created = created;
            Updated = updated;
            ProductId = productId;
            UserId = userId;
            OrderId = orderId;
        }
        
        public static Feedback Create(FeedbackId id,
                                      short rating,
                                      string text,
                                      ProductId productId,
                                      UserId userId,
                                      OrderId orderId)
        {
            return new Feedback(FeedbackId.Create(),
                rating,
                text,
                DateTime.UtcNow,
                DateTime.UtcNow,
                productId,
                userId,
                orderId);
        }
    }
}
