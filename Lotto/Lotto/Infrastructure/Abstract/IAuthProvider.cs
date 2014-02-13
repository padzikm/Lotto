using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotto.Models;

namespace Lotto.Infrastructure
{
    public interface IAuthProvider
    {
        User Authenticate(string name, string password);
    }
}
