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
    public class ChambreReserveeViewModel : ViewModelBase
    {
        public ChambreReserveeService Srv;

        #region "Propriétés de la table"
        private ChambreReservee _chambreReservee;
        private ObservableCollection<DemandeOption> _ListeDemandeOptions;
        public ObservableCollection<DemandeOption> ListeDemandeOptions
        {
            get
            {
                return _ListeDemandeOptions;
            }
            set
            {
                _ListeDemandeOptions = value;
            }
        }
        private DemandeOption _CurrentSelectionDOption;
        public DemandeOption currentSelection
        {
            get
            {
                return _CurrentSelectionDOption;
            }
            set
            {
                _CurrentSelectionDOption = value;
                NotifyPropertyChanged();
            }
        }
        public ChambreReservee ChambreReservee
        {
            get { return _chambreReservee; }
            set { _chambreReservee = value; NotifyPropertyChanged(); }
        }

        public int ID
        {
            get
            {
                return ChambreReservee.Id;
            }
            set
            {
                ChambreReservee.Id = value;
                NotifyPropertyChanged();
            }
        }

        public int NbPersonne
        {
            get
            {
                return ChambreReservee.NbPersonne;
            }
            set
            {
                ChambreReservee.NbPersonne = value;
                NotifyPropertyChanged();
            }
        }

        public int NumeroChambre
        {
            get
            {
                return ChambreReservee.Numero;
            }
            set
            {
                ChambreReservee.Numero = value;
                NotifyPropertyChanged();
            }
        }

        public int IdRes
        {
            get
            {
                return ChambreReservee.IdentifiantRes;
            }
            set
            {
                ChambreReservee.IdentifiantRes = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
        public ChambreReserveeViewModel(ChambreReserveeService srv, ChambreReservee cr)
        {
            Srv = srv;
            ChambreReservee = cr;
            List<DemandeOption> dOption =srv.getOptionDemande(cr.Id);
            List<Option> options = srv.GetOptions();
            _ListeDemandeOptions = new ObservableCollection<DemandeOption>();
            foreach (DemandeOption optionD in dOption) _ListeDemandeOptions.Add(optionD);
        }

        #region "Commandes
        private RelayCommand _commandeSupprimerChambreReservees;
        public ICommand CommandeSupprimerChambreReservees
        {
            get
            {
                if (_commandeSupprimerChambreReservees == null)
                {
                    _commandeSupprimerChambreReservees = new RelayCommand(SupprimerChambreReservee);
                }
                return _commandeSupprimerChambreReservees;
            }
        }
        public event EventHandler ChambreReserveeSupprimee;
        // Suppression
        public void SupprimerChambreReservee()
        {
            Srv.RemoveChambreReservee(ID);
            ChambreReserveeSupprimee?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region "Fonctions modification"
        // Enregistrement
        public void EnregistrerChambreReservee()
        {
            if (ID == 0)
            {
                Srv.AddChambreReservee(ChambreReservee);
            }
            else
            {
                Srv.UpdateChambreReservee(ChambreReservee);
            }
        }


        #endregion

    }
}
