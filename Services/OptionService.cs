using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    class OptionService
    {
        #region Singleton
        private static OptionService instance;
        public static OptionService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OptionService();
                }
                return instance;
            }
        }
        #endregion
        public List<Option> GetOptions()
        {
            List<Option> options = new List<Option>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                foreach (Option option in context.Options)
                {
                    options.Add(option);
                }
            }
            return options;
        }
        public List<DemandeOption> getOptionDemande(int chambreID)
        {
            List<DemandeOption> dOptions = new List<DemandeOption>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                foreach (DemandeOption option in context.DemandeOptions)
                {
                    if (option.IdChambreReservee == chambreID)
                    {
                        dOptions.Add(option);
                    }
                }
            }
            return dOptions;
        }
        public void AddDemandeOption(Option opt, ChambreReservee chambre)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                DemandeOption demandeOption = new DemandeOption();
                demandeOption.ChambreReservee = chambre;
                demandeOption.IdChambreReservee = chambre.Id;
                demandeOption.NbJour = 0;
                demandeOption.Option = opt;
                demandeOption.IdOption = opt.NumOption;
                context.DemandeOptions.Add(demandeOption);
            }
        }
    }
}
