using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ReservationService
    {
        #region Singleton
        private static ReservationService instance;
        public static ReservationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReservationService();
                }
                return instance;
            }
        }
        #endregion

        public int AddReservation(Reservation resa)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (resa != null)
                {
                    resa.DateReservation = DateTime.Now;
                    context.Reservations.Add(resa);
                    context.SaveChanges();
                }
            }
            return resa.IdentifiantRes;
        }

        public Reservation GetReservation(int id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Reservations.Find(id);
            }
        }

        public List<Reservation> GetReservations()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Reservations.ToList();
            }
        }

        public List<ChambreReservee> GetChambresReservées(int? idResa)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return (from cr in context.ChambreReservees
                        where cr.IdentifiantRes == idResa
                        select cr).ToList();
            }
        }

        public void UpdateReservation(Reservation resa)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Reservation resaToUpdate = context.Reservations.Find(resa.IdentifiantCli);
                if (resaToUpdate != null)
                {
                    resaToUpdate.IdentifiantCli = resa.IdentifiantCli;
                    resaToUpdate.DateDebutSejour = resa.DateDebutSejour;
                    resaToUpdate.NbNuits = resa.NbNuits;
                    context.SaveChanges();
                }
            }
        }

        public void RemoveReservation(int? id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Reservation resaToRemove = context.Reservations.Find(id);
                if (resaToRemove != null)
                {
                    context.Reservations.Remove(resaToRemove);
                    context.SaveChanges();
                }
            }
        }

    }

}
