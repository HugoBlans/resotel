using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ReservationService
    {
        public List<Reservation> AfficherReservation()
        {
            List<Reservation> listReservation = new List<Reservation>();

            using(Entities.AppContext context = new Entities.AppContext())

            return listReservation;
        }
        

        


    }
}
