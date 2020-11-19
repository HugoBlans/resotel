using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private OptionVueModel _currentOptionVueModel;
        public OptionVueModel CurrentOptionVm
        {
            get
            {
                return _currentOptionVueModel;
            }
            set
            {
                _currentOptionVueModel = value;
                Opt.Option = value.opt;
                Opt.IdOption = value.opt.NumOption;
                NotifyPropertyChanged();
            }
        }
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
        }
        public int idCHambreR
        {
            get
            {
                return _opt.IdChambreReservee;
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
                return _opt.ChambreReservee;
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
                return _opt.IdOption;
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
                return _opt.Option;
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
                return _opt.NbJour;
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
            if(_opt != null)
            {
                service.RemoveOption(_opt.IdOption);
            }
            suppresion?.Invoke(this, EventArgs.Empty);
        }
    }

}
