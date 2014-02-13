using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lotto.Models;
using Lotto.Database;
using WebMatrix.WebData;

namespace Lotto.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        private LottoDbContext dbContext = new LottoDbContext();

        public User Authenticate(string name, string password)
        {
            return dbContext.Users.FirstOrDefault(p => p.Name == name && p.Password == password);            
        }
    }
}