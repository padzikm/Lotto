using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lotto.Database;
using Lotto.Models;

namespace Lotto.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private LottoDbContext dbContext = new LottoDbContext();

        public bool AddUser(string name, string password)
        {                        
            User user = dbContext.Users.FirstOrDefault(p => p.Name == name);
            if (user == null)
            {
                User newUser = new User() { Name = name, Password = password };
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUser(string name, string password)
        {
            return dbContext.Users.FirstOrDefault(p => p.Name == name && p.Password == password);
        }

        public bool IsAdmin(string name, string password)
        {
            User user = dbContext.Users.FirstOrDefault(p => p.Name == name && p.Password == password);

            return (user != null && user.IsAdmin);
        }
    }
}