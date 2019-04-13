namespace AccountManager.Data.Factory
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class AcountManagerDesignTimeFactory
        : IDesignTimeDbContextFactory<AccountManagerDBContext>
    {        
        public AccountManagerDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = 
                new DbContextOptionsBuilder<AccountManagerDBContext>();

            optionsBuilder.UseSqlServer(@"Server=LPTPJDIVISON\SQLEXPRESS; DataBase=AccountManagerDb; Integrated Security=true;",
                options => options.MigrationsAssembly(typeof(AccountManagerDBContext).Assembly.FullName));
            return new AccountManagerDBContext(optionsBuilder.Options);
        }
    }
}
