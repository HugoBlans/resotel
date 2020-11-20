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
        public void AddDemandeOption(DemandeOption opt)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                context.DemandeOptions.Add(opt);
                context.SaveChanges();
            }
        }
        public void UpdateDemandeOption(DemandeOption option)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                DemandeOption optionToSave = (from opt in context.DemandeOptions where (opt.IdChambreReservee == option.IdChambreReservee) && (opt.IdOption == option.IdOption) select opt).SingleOrDefault<DemandeOption>();
                optionToSave.IdOption = option.IdOption;
                optionToSave.IdChambreReservee = option.IdChambreReservee;
                optionToSave.NbJour = option.NbJour;
                context.SaveChanges();
            }
        }
        public void RemoveOption(DemandeOption option)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                try
                {
                    DemandeOption optionToRemove = (from opt in context.DemandeOptions where (opt.IdChambreReservee == option.IdChambreReservee) && (opt.IdOption == option.IdOption) select opt).SingleOrDefault<DemandeOption>();
                    if (optionToRemove != null)
                    {
                        context.DemandeOptions.Remove(optionToRemove);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    return;
                }
            }
        }
        public bool CheckData(DemandeOption option)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                DemandeOption Dopt = (from opt in context.DemandeOptions where (opt.IdChambreReservee == option.IdChambreReservee) && (opt.IdOption == option.IdOption) select opt).SingleOrDefault<DemandeOption>();

                return Dopt != null;
            }
        }
        public double calculPrix(int idOption, int nbJour)
        {
            double TmpPrix = 0;
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Option option = context.Options.Find(idOption);
                TmpPrix = nbJour * (double)option.Prix;
            }
            return TmpPrix;
        }
    }
}
