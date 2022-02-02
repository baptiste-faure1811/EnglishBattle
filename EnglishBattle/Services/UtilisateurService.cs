using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Services
{
    public class UtilisateurService
    {
        private EnglishBattleDataBaseEntities context;

        public UtilisateurService(EnglishBattleDataBaseEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retourne un objet métier
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>objet métier</returns>
        public Joueur GetItem(int id)
        {
            using (context)
            {
                return context.Joueur.Find(id);
            }
        }

        public Joueur GetItem(string email, string password)
        {
            using (context)
            {
                IQueryable<Joueur> utilisateurs = from utilisateur in context.Joueur
                                                  where utilisateur.email == email
                                                       && utilisateur.motDePasse == password
                                                       select utilisateur;

                return utilisateurs.FirstOrDefault();
            }
        }

        public List<Joueur> GetList()
        {
            using (context)
            {
                return context.Joueur.ToList();

            }
        }

        public void Insert(Joueur utilisateur)
        {
            using (context)
            {
                context.Joueur.Add(utilisateur);
                context.SaveChanges();
            }
        }

        public void Update(Joueur utilisateur)
        {
            using (context)
            {
                context.Entry(utilisateur).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Joueur utilisateur)
        {
            using (context)
            {
                context.Entry(utilisateur).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
