using AccountManager.Data;
using AccountManager.Data.DataServices;
using AccountManager.Data.Factory;
using AccountManager.Data.Models;
using AccountManager.Data.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManager.Test
{
    [TestClass]
    public class AccountTypeData
    {
        private AccountTypeDataService dataService;

        public AccountTypeData()
        {
            var factory = new AccountManagerDesignTimeFactory();
            AccountManagerDbContext context = factory.CreateDbContext(new string[] { });


            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile<MapperProfile>();
            });
            dataService = new AccountTypeDataService(mapperConfiguration.CreateMapper(), context);
        }

        [TestMethod]
        public void AddOk()
        {
            int rowsAffected = 0;
            AccountTypeDTO accountType = new AccountTypeDTO
            {
                Code = "PAS",
                Name = "Pasivos"
            };

            rowsAffected = dataService.AddOrUpdate(accountType);

            Assert.AreNotEqual(0, rowsAffected);
        }
    }
}
