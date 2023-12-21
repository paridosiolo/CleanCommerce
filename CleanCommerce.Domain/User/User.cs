using CleanCommerce.Domain.Cart.ValueObjects;
using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.Models.User.ValueObjects;
using CleanCommerce.Domain.Feedback.ValueObjects;
using CleanCommerce.Domain.Order.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {

        private readonly List<OrderId> _orderIds = new();
        private readonly List<FeedbackId> _feedbackIds = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public DateTime Created { get; }
        public DateTime LastLogin { get; }
        public bool IsAuthenticated { get; }

        public CartId CartId { get; }

        public IReadOnlyList<OrderId> OrderIds => _orderIds.AsReadOnly();
        public IReadOnlyList<FeedbackId> FeedbackIds => _feedbackIds.AsReadOnly();
        private User(UserId id,
                     string firstName,
                     string lastName,
                     string email,
                     string password,
                     string role,
                     CartId cartId,
                     DateTime created,
                     DateTime lastLogin,
                     bool isAuthenticated) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            CartId = cartId;
            Created = created;
            LastLogin = lastLogin;
            IsAuthenticated = isAuthenticated;
        }

        public static User Create(string firstName,
                                  string lastName,
                                  string email,
                                  string password,
                                  string role)

        {
            return new User(UserId.Create(),
                            firstName,
                            lastName,
                            email,
                            password,
                            role,
                            CartId.Create(),
                            DateTime.UtcNow,
                            DateTime.UtcNow,
                            false);
        }
    }
}
