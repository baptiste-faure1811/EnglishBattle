using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishBattleApp.Models
{
    public class InscriptionViewModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [StringLength(20, ErrorMessage = "Le mot de passe doit comporter au moins {2} charactères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "La confirmation de mot de passe ne correspond pas.")]
        public string ConfirmationPassword { get; set; }

        [Required]
        [Display(Name = "Niveau")]
        public int Level { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public int City { get; set; }
    }
}