using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    class RepasService
    {
        #region Singleton
        private static RepasService instance;
        public static RepasService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepasService();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        ///  Permet de recuperer la liste des chambre résérvé avec les chambre associé
        /// </summary>
        /// <returns></returns>
        public List<ChambreReservee> chargerListChambre()
        {
            List<ChambreReservee> lst = new List<ChambreReservee>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                lst = context.ChambreReservees.ToList();
            }
            return lst;
        }
        public List<RepasJour> chargerRepasHebdo(DateTime date)
        {
            DateTime dateFin = date.AddDays(7);
            List<RepasJour> lst = new List<RepasJour>();
            for (DateTime curDate = date; curDate < dateFin; curDate = curDate.AddDays(1))
            {
                lst.Add(new RepasJour(curDate));
            }
            return lst;
        }
        public Repas Enregistrer(Repas repas)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (repas.Id > 0)
                {
                    context.Repas.Attach(repas);
                    context.Entry(repas).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Repas.Add(repas);
                }
                context.SaveChanges();
            }
            return repas;
        }
    }
}
