using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotto.Models;

namespace Lotto.Infrastructure
{
    public interface IUserRepository
    {
        bool AddUser(string name, string password);
        User GetUser(string name, string password);
        bool IsAdmin(string name, string password);
    }
}
