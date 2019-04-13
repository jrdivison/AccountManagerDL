namespace AccountManager.Data.Models
{
    using System.Collections.Generic;
    using AccountManager.Data.Core;   

    public class AccountType : ModelBase<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
