using CleanCommerce.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetUserByEmail(string email);
    }
}
