using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    public class OptionDemandeVueModel : ViewModelBase
    {
        private OptionService service;
        private DemandeOption _opt;
        public DemandeOption Opt
        {
            get { return _opt; }
            set { _opt = value; NotifyPropertyChanged(); }
        }
        private ObservableCollection<OptionVueModel> _optionVueModels;
        public ObservableCollection<OptionVueModel> OptionVueModels
        {
            get { return _optionVueModels; }
            set { _optionVueModels = value; }
        }
        private void CurrentChangedOption(Object sender, EventArgs e)
        {
            OptionVueModel value = observerOption.CurrentItem as OptionVueModel;
            Opt.Option = value.opt;
            Opt.IdOption = value.opt.NumOption;
        }

        private readonly ICollectionView observerOption;
        public OptionDemandeVueModel(DemandeOption dOpt)
        {
            service = Services.OptionService.Instance;
            Opt = dOpt;
            OptionVueModels = new ObservableCollection<OptionVueModel>();
            List<Option> options = service.GetOptions();
            foreach (Option option in options)
            {
                OptionVueModel optionVue = new OptionVueModel(option);
                OptionVueModels.Add(optionVue);
            }
            observerOption = CollectionViewSource.GetDefaultView(OptionVueModels);
            observerOption.CurrentChanged += CurrentChangedOption;
        }
        public int idCHambreR
        {
            get
            {
                return Opt.IdChambreReservee;
            }
            set
            {
                Opt.IdChambreReservee = value;
            }
        }
        public ChambreReservee ChambreR
        {
            get
            {
                return Opt.ChambreReservee;
            }
            set
            {
                Opt.ChambreReservee = value;
            }
        }
        public int OptionId
        {
            get
            {
                return Opt.IdOption;
            }
            set
            {
                Opt.IdOption = value;
            }
        }
        public Option Option
        {
            get
            {
                return Opt.Option;
            }
            set
            {
                Opt.Option = value;
            }
        }
        public int Jour
        {
            get
            {
                return Opt.NbJour;
            }
            set
            {
                Opt.NbJour = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand AddJour
        {
            get
            {
                return new RelayCommand(addJour);
            }
        }
        private void addJour(object jour)
        {
            string value = (string)jour;
            int nbSupp;
            if (Int32.TryParse(value, out nbSupp))
                Jour += nbSupp;
            if (Jour < 0) Jour = 0;
        }

        public ICommand RemoveOption
        {
            get
            {
                return new RelayCommand(removeOption);
            }
        }
        public EventHandler suppresion;
        private void removeOption()
        {
            if (Opt != null)
            {
                service.RemoveOption(Opt);
            }
            suppresion?.Invoke(this, EventArgs.Empty);
        }
        public void Enregistrer()
        {
            if (Opt != null && ChambreR != null)
            {
                if (service.CheckData(Opt))
                {
                    service.UpdateDemandeOption(Opt);
                }
                else
                {
                    service.AddDemandeOption(Opt);
                }
            }
        }
    }
}
