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
        public ObservableCollection<KeyValuePair<ChambreReservee, Entities.Chambre>> chargerListChambre()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Dictionary<ChambreReservee, Chambre> chambre = context.ChambreReservees
                    .Join
                    (
                    context.Chambres,
                    Cham => Cham.Numero, ChamRese => ChamRese.Numero,
                    (Cham, ChamRese) => new
                    {
                        cham = Cham,
                        chamRese = ChamRese
                    }
                    ).ToDictionary(x => x.cham, x => x.chamRese);
                return new ObservableCollection<KeyValuePair<ChambreReservee, Entities.Chambre>>(chambre);
            }
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
