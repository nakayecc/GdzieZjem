using System.Collections.Generic;
using System.Linq;
using GdzieZjemAPI.Models;

namespace GdzieZjemAPI.Helpers
{
    public static class ExtensionUser
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(user => user.WithoutPassword());
        }

        private static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}