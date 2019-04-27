using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Factory
{
    public class AccountManagerDesignTimeFactory
        : IDesignTimeDbContextFactory<AccountManagerDbContext>
    {
        public AccountManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = 
                new DbContextOptionsBuilder<AccountManagerDbContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AccountManagerModule;Integrated Security=True;",
                option=> option.MigrationsAssembly(
                    typeof(AccountManagerDbContext).Assembly.FullName));

            return new AccountManagerDbContext(optionsBuilder.Options);
        }
    }
}
