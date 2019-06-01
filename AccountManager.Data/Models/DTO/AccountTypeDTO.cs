using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class AccountTypeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Codigo")]
        public string Code { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
