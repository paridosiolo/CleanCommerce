using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.User.Extensions
{
    public static class UserExtensions
    {
        public static void AddRole(this User user, string roleName)
        {
            user.Roles.Add(roleName);
        }
    }
}
