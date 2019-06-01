using AccountManager.Data.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data
{
    public class AccountManagerDbContext : DbContext
    {
        public AccountManagerDbContext(
            DbContextOptions<AccountManagerDbContext> options) : base(options)
        {
        }

        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Account { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>()
                .HasKey(r => r.Id);


            modelBuilder.Entity<Account>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<AccountType>()
                .HasIndex(r => r.Code)
                .IsUnique(true);

            modelBuilder.Entity<Account>()
                .HasIndex(r => r.Code)
                .IsUnique(true);

            modelBuilder.Entity<Account>()
                .HasOne(r => r.AccountType)
                .WithMany(r => r.Accounts)
                .OnDelete(DeleteBehavior.Restrict);


            AccountType accountType = new AccountType()
            {
                Id = 1,
                Code = "1.",
                Name = "Activos",
            };

            var account1 = new List<Account>()
                {
                    new Account(){ Id = 1, Code = "1.1", Name = "Caja y Bancos", AccountTypeId = 1},
                    new Account(){ Id = 2,Code = "1.2", Name = "Activo Circulante", AccountTypeId = 1},
                    new Account(){ Id = 3,Code = "1.3", Name = "Efectivo", AccountTypeId = 1},
                    new Account(){ Id = 4,Code = "1.4", Name = "Cuentas por Cobrar", AccountTypeId = 1}
                };

            AccountType accountType1 = new AccountType()
            {
                Id = 2,
                Code = "2.",
                Name = "Pasivos",
            };

            var accounts2 = new List<Account>()
                {
                    new Account(){ Id = 5, Code = "2.1", Name = "Pasivo y Capital", AccountTypeId = 2},
                    new Account(){ Id = 6,Code = "2.2", Name = "Cuentas por Pagar", AccountTypeId = 2},
                    new Account(){ Id = 7,Code = "2.3", Name = "Efectos por Pagar", AccountTypeId = 2}
                };

            modelBuilder.Entity<AccountType>()
                .HasData(accountType, accountType1);

            modelBuilder.Entity<Account>()
                .HasData(account1);

            modelBuilder.Entity<Account>()
                .HasData(accounts2);

        }
    }
}
