using AccountManager.Data.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.DataServices
{
    public class AccountDataService
        : DataServiceBase<AccountDataService, AccountManagerDbContext>
    {
        public AccountDataService(IMapper mapper, AccountManagerDbContext context) 
            : base(mapper, context)
        {
        }
    }
}
