namespace AccountManager.Data.DataServices
{
    using AccountManager.Data.Core;
    using AccountManager.Data.Models;
    using AutoMapper;

    public class AccountDataService 
        : DataServiceBase<AccountDataService, AccountManagerDBContext>
    {
        public AccountDataService(IMapper mapper,
            AccountManagerDBContext context)
            : base(mapper, context)
        {

        }
    }
}
