using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishBattleApp.Models
{
    public class ConnexionViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}