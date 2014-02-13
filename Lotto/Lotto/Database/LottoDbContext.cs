using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Runtime.Remoting.Contexts;
using System.Runtime.CompilerServices;
using Lotto.Models;

namespace Lotto.Database
{
    public class LottoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LottoDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LottoDbContext>());
        }
    }
}