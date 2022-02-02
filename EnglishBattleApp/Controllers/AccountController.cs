using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishBattle.Services;
using EnglishBattleApp.Models;

namespace EnglishBattleApp.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            ViewBag.Message = "Requette GET";

            // renvoie la vue
            return View();
        }

        public ActionResult Login()
        {
            // renvoie la vue
            return View();
        }


        [HttpPost]
        public ActionResult Login(ConnexionViewModel model)
        {
            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                // ici on vérifie si l'utilisateur en base de données
                UtilisateurService utilisateurService = new UtilisateurService(new TestEF.Data.TestEFEntities());

                Utilisateur utilisateur = utilisateurService.GetItem(model.Email, model.Password);

                if (utilisateur != null)
                {
                    // ajoute l'utilisateur dans la session
                    Session["utilisateur"] = utilisateur;

                    // effectue un redirect avec l'url Home/Index
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(InscriptionViewModel model)
        {
            ViewBag.Message = "Requette POST";

            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                // ici on enregistre l'utilisateur en base de données
                UtilisateurService utilisateurService = new UtilisateurService(new TestEF.Data.TestEFEntities());

                // créé un utilisateur
                Utilisateur utilisateur = new Utilisateur();

                utilisateur.Nom = model.Nom;
                utilisateur.Prenom = model.Prenom;
                utilisateur.Email = model.Email;
                utilisateur.Password = model.Password;

                utilisateurService.Insert(utilisateur);

                // effectue un redirect avec l'url Home/Index
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}