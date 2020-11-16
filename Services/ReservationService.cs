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

        /// <summary>
        /// Permet d'afficher la liste des réservation et clients associés
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<KeyValuePair<Reservation, Entities.Client>> chargerListResa()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                // FROM
                Dictionary<Reservation, Client> resa = context.Reservations
                    .Join(
                        // JOIN
                        context.Clients,
                        // ON
                        Res => Res.IdentifiantCli,
                        Cli => Cli.IdentifiantCli,
                        // SELECT
                        (Res, Cli) => new
                        {
                            cli = Cli,
                            res = Res
                        }
                    ).ToDictionary(x => x.res, x => x.cli);
                return new ObservableCollection<KeyValuePair<Reservation, Entities.Client>>(resa);
            }
        }

        public Reservation Enregistrer(Reservation resa)
        {
            using(Entities.AppContext context = new Entities.AppContext())
            {
                if (resa.IdentifiantRes > 0)
                {
                    context.Reservations.Attach(resa);
                    context.Entry(resa).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Reservations.Add(resa);
                }
                context.SaveChanges();
            }
            return resa;
        }

    }

}
