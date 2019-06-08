using AccountManager.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountManager.API.MVC.Models
{
    public class AccountTypeDTO
    { 
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MinLength(2, ErrorMessage = "{0} debe tener al menos dos (2) caracteres")]
        [Display(Name = "Codigo o Identificador")]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
