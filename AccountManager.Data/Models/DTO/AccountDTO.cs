using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class AccountDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
        public ViewModelParent<int> AccountType { get; set; }
        public int AccountTypeId { get; set; }
    }
}
