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
    class NewRepasVueModel : ViewModelBase
    {
        private RepasService serv;
        private Repas newRep;
        private ObservableCollection<KeyValuePair<ChambreReservee, Entities.Chambre>> edibleRoom;

        public ObservableCollection<KeyValuePair<ChambreReservee, Entities.Chambre>> pEdibleRoom
        {
            get
            {
                return edibleRoom;
            }
            set
            {
                edibleRoom = value;
                NotifyPropertyChanged(nameof(pEdibleRoom));
            }
        }

        public NewRepasVueModel()
        {
            serv = RepasService.Instance;
            pEdibleRoom = serv.chargerListChambre();
            newRep = new Repas();
        }

        public Repas rep
        {
            get { return newRep; }
        }
        private bool isPetitDejeuner
        {
            set
            {
                newRep.EstPetitDejeuner = value;
                NotifyPropertyChanged();
            }
            get { return isPetitDejeuner; }
        }
        private DateTime date
        {
            set
            {
                newRep.DateRepas = value;
            }
            get { return date; }
        }
        public ICommand RepasEnregistrer
        {
            get
            {
                return new RelayCommand(enregistrer);
            }
        }
        private void enregistrer()
        {
            newRep = serv.Enregistrer(newRep);
        }
    }
}
