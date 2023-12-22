using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new();

        public void Add (User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
        public User? GetUserById(Guid userId)
        {
            return _users.SingleOrDefault(u => u.Id.Value == userId);
        }
    }
}
