using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ChambresANettoyerService
    {
        #region Singleton 

        private static ChambresANettoyerService instance;
        public static ChambresANettoyerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChambresANettoyerService();
                }
                return instance;
            }
        }

        private ChambresANettoyerService()
        {

        }
        #endregion

        public List<Chambre> getChambresANettoyer(int numEtage)
        {
            List<Chambre> chambres = new List<Chambre>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                chambres = context.Database.SqlQuery<Chambre>("CALL menageByEtage("+ numEtage +")").ToList();
                return chambres;
            }
        }

        internal void ChambreEstNettoyee(int numero)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                context.Database.ExecuteSqlCommand("UPDATE Chambres SET DateDernierMenage = '"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"' WHERE Chambres.Numero = " + numero);
            }
        }
    }
}
