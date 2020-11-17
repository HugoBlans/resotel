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
    }
}
