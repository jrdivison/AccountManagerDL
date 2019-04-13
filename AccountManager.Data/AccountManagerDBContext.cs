namespace AccountManager.Data
{
    using AccountManager.Data.Models;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    public class AccountManagerDBContext : DbContext
    {
        public AccountManagerDBContext(DbContextOptions<AccountManagerDBContext> options) : base(options)
        {
        }

        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //No se require ya que el DBContext no genera ningun codigo.
            //Si uso mi propio DBContext entonces si es necesario.
            //base.OnModelCreating(modelBuilder);
           
            /* Clave Primaria con mas de un campo
            modelBuilder.Entity<AccountType>()
               .HasKey(k => new {k.Id, k.Name});
            */
            modelBuilder.Entity<AccountType>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Account>()
                .HasOne(k => k.AccountType)
                .WithMany(k => k.Accounts)
                .OnDelete(DeleteBehavior.Restrict);//Desactiva eliminacion en cascada
        }
    }
}
