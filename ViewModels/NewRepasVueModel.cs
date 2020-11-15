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

        private ObservableCollection<ChambreReservee> edibleRoom;
        public ObservableCollection<ChambreReservee> pEdibleRoom
        {
            get
            {
                return edibleRoom;
            }
            set
            {
                edibleRoom = value;
            }
        }

        private ChambreReservee _currentSelection;
        public ChambreReservee currentSelection
        {
            get
            {
                return _currentSelection;
            }
            set
            {
                if (_currentSelection == value) return;
                _currentSelection = value;
                newRep.ChambreReservee = value;
                NotifyPropertyChanged();
            }
        }

        public NewRepasVueModel()
        {
            serv = RepasService.Instance;
            List<ChambreReservee> lst = serv.chargerListChambre();
            edibleRoom = new ObservableCollection<ChambreReservee>();

            foreach (ChambreReservee chambre in lst)
            {
                edibleRoom.Add(chambre);
            }
            newRep = new Repas();
        }

        public Repas rep
        {
            get { return newRep; }
        }
        public bool isPetitDejeuner
        {
            set
            {
                newRep.EstPetitDejeuner = value;
                NotifyPropertyChanged();
            }
            get { return newRep.EstPetitDejeuner; }
        }
        public DateTime date
        {
            set
            {
                newRep.DateRepas = value;
                NotifyPropertyChanged();
            }
            get { return newRep.DateRepas; }
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
