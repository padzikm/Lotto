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


        public IEnumerable<User> GetAllInActiveUsers()
        {
            return dbContext.Users.Where(p => !p.IsActive).ToList();
        }

        public bool SaveUser(User user)
        {
            User modifiedUser = dbContext.Users.FirstOrDefault(p => p.UserID == user.UserID);

            modifiedUser.Name = user.Name;
            modifiedUser.Password = user.Password;
            modifiedUser.IsActive = user.IsActive;
            modifiedUser.IsAdmin = user.IsAdmin;
            
            dbContext.SaveChanges();

            return true;
        }


        public User GetUser(int userID)
        {
            return dbContext.Users.FirstOrDefault(p => p.UserID == userID);
        }


        public bool DeleteUser(int userID)
        {
            User user = dbContext.Users.FirstOrDefault(p => p.UserID == userID);
            
            if(user != null)
                dbContext.Users.Remove(user);

            dbContext.SaveChanges();

            return true;
        }
    }
}