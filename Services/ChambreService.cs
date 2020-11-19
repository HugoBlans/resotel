using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ChambreService
    {
        public void AddChambre(Chambre chambre)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (chambre != null)
                {
                    context.Chambres.Add(chambre);
                    context.SaveChanges();
                }
            }
        }

        public Chambre GetChambre(int id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Chambres.Find(id);
            }
        }

        public List<Chambre> GetAllChambres()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Chambres.ToList();
            }
        }

        public void UpdateChambre(Chambre chambre)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Chambre chambresToUpdate = context.Chambres.Find(chambre.Numero);
                if (chambresToUpdate != null)
                {
                    chambresToUpdate.Numero = chambre.Numero;
                    chambresToUpdate.NumEtage = chambre.NumEtage;
                    chambresToUpdate.NbLit = chambre.NbLit;
                    chambresToUpdate.LitEnfant = chambre.LitEnfant;
                    chambresToUpdate.LitDouble = chambre.LitDouble;
                    chambresToUpdate.DateDernierMenage = chambre.DateDernierMenage;
                    context.SaveChanges();
                }
            }
        }

        public void RemoveChambre(int id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Chambre chambreToRemove = context.Chambres.Find(id);
                if (chambreToRemove != null)
                {
                    context.Chambres.Remove(chambreToRemove);
                    context.SaveChanges();
                }
            }
        }
    }
}
