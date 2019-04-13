namespace AccountManager.Test
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AccountManager.Data;
    using AccountManager.Data.Factory;
    using AccountManager.Data.Models;

    [TestClass]
    public class AccountTypeData
    {
        private AccountManagerDBContext context;

        public AccountTypeData()
        {
            var factory = new AcountManagerDesignTimeFactory();
            context = factory.CreateDbContext(new string[] { });
            //t context.Database.Migrate();
        }

        [TestMethod]
        public void AddOk()
        {
            int rowsAffected = 0;
            AccountType accountType = new AccountType
            {
                Code = "ACT",
                Name = "Acivos"
            };

            context.AccountType.Add(accountType);

            if (context.ChangeTracker.HasChanges())
            {
                rowsAffected = context.SaveChanges();
            }

            Assert.AreNotEqual(0, rowsAffected);
        }
    }
}
