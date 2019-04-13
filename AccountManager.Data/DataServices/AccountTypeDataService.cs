using AccountManager.Data.Core;
using AccountManager.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.DataServices
{
    public class AccountTypeDataService :
        DataServiceBase<AccountType, int, AccountManagerDBContext>
    {
        public AccountTypeDataService(IMapper mapper, 
            AccountManagerDBContext context) 
            : base(mapper, context)
        {

        }
    }
}
