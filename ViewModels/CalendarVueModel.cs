using MySql.Data.MySqlClient;
using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    class CalendarVueModel
    {
        public List<Repas> loadDailyMeal()
        {
            List<Repas> lst;
            using(Entities.AppContext context = new Entities.AppContext())
            {
                lst = context.Repas.ToList();
            }
            return lst;
        }
    }
}
