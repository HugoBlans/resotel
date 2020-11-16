using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetRESOTEL.Entities;

namespace ProjetRESOTEL.Services
{
    class CalendarService
    {
        public List<Repas> loadDailyMeal()
        {
            List<Repas> lst;
            using (Entities.AppContext context = new Entities.AppContext())
            {
                lst = context.Repas.ToList();
            }
            return lst;
        }
    }
}
