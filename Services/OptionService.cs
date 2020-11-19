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
        public void UpdateDemandeOption(DemandeOption opt)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                DemandeOption optionToSave = context.DemandeOptions.Find(opt);
                optionToSave.Option = opt.Option;
                optionToSave.IdOption = opt.IdOption;
                optionToSave.ChambreReservee = opt.ChambreReservee;
                optionToSave.IdChambreReservee = opt.IdChambreReservee;
                optionToSave.NbJour = opt.NbJour;
                context.SaveChanges();
            }
        }
        public void RemoveOption(DemandeOption Id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                try
                {
                    DemandeOption optionToRemove = context.DemandeOptions.Find(Id);
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
            using (Entities.AppContext context= new Entities.AppContext())
            {
                try
                {
                    DemandeOption demandeOption = context.DemandeOptions.Find(option);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
