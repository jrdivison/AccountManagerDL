using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.MVC.Models
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "No coinciden los passwords")]
        public string VerifyPassword { get; set; }
    }
}
