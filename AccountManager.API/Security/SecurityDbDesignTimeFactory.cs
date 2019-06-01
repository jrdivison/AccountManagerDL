using AccountManager.API.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Factory
{
    public class SecurityDbDesignTimeFactory
        : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        public SecurityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = 
                new DbContextOptionsBuilder<SecurityDbContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SecurityDB;Integrated Security=True",
                option=> option.MigrationsAssembly(
                    typeof(SecurityDbContext).Assembly.FullName));

            var ctx = new SecurityDbContext(optionsBuilder.Options);
                 return ctx;
        }
    }
}
