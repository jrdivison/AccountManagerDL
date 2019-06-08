using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.API.MVC.Models
{
    public class ViewModelParent<TId>
    {
        public TId Id { get; set; }
        public string Description { get; set; }

    }
}
