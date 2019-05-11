using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }


        public ViewModelParent<int> AccountType { get; set; }        
    }
}
