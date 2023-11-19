using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Entities;
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
    }
}
