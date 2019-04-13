using AccountManager.Data;
using AccountManager.Data.Factory;
using AccountManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManager.Test
{
    [TestClass]
    public class AccountTypeData
    {
        private AccountManagerDbContext context;

        public AccountTypeData()
        {
            var factory = new AccountManagerDesignTimeFactory();
            context = factory.CreateDbContext(new string[] { });
            context.Database.Migrate();
        }

        [TestMethod]
        public void AddOk()
        {
            int rowsAffected = 0;
            AccountType accountType = new AccountType
            {
                Code = "ACT",
                Name = "Activos"
            };

            context.AccountType.Add(accountType);

            if (context.ChangeTracker.HasChanges())
                rowsAffected = context.SaveChanges();

            Assert.AreNotEqual(0, rowsAffected);
        }
    }
}
