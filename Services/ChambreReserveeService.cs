using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ChambreReserveeService
    {
        public int? AddChambreReservee(ChambreReservee cr)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (cr != null)
                {
                    context.ChambreReservees.Add(cr);
                    context.SaveChanges();
                }
            }
            return cr.Id;
        }

        public ChambreReservee GetChambreReservee(int id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.ChambreReservees.Find(id);
            }
        }

        public List<ChambreReservee> GetAllChambreReservees()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.ChambreReservees.ToList();
            }
        }

        public void UpdateChambreReservee(ChambreReservee cr)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                ChambreReservee crToUpdate = context.ChambreReservees.Find(cr.Id);
                if (crToUpdate != null)
                {
                    //crToUpdate.Nom = cr.Nom;
                    //crToUpdate.Prenom = cr.Prenom;
                    //crToUpdate.Telephone = cr.Telephone;
                    //crToUpdate.Email = cr.Email;
                    //context.SaveChanges();
                }
            }
        }

        public void RemoveChambreReservee(int? id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                ChambreReservee crToRemove = context.ChambreReservees.Find(id);
                if (crToRemove != null)
                {
                    context.ChambreReservees.Remove(crToRemove);
                    context.SaveChanges();
                }
            }
        }
        public List<DemandeOption> getOptionDemande(int chambreID)
        {
            List<DemandeOption> dOptions = new List<DemandeOption>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                foreach (DemandeOption option in context.DemandeOptions)
                {
                    if (option.IdChambreReservee == chambreID)
                    {
                        dOptions.Add(option);
                    }
                }
            }
            return dOptions;
        }
        public List<Option> GetOptions()
        {
            List<Option> options = new List<Option>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                foreach(Option option in context.Options)
                {
                    options.Add(option);
                }
            }
            return options;
        }
    }
}
