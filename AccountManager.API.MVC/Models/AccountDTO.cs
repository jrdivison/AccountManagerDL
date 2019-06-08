using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.API.MVC.Models
{
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ViewModelParent<int> AccountType { get; set; }
    }
}
