using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class ReservationModel : ViewModelBase
    {
        // Entité du modèle
        private Reservation reservation;

        // Accesseur
        public Reservation Reservation
        {
            get { return reservation; }
        }

        public ReservationModel(Reservation resa)
        {
            if (resa == null)
            {
                throw new NullReferenceException("Reservation");
            }
            reservation = resa;
        }

    }
}
