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
    public class ChambreReserveeViewModel : ViewModelBase
    {
        public ChambreReserveeService Srv;

        #region "Propriétés de la table"
        private ChambreReservee _chambreReservee;
        private ObservableCollection<OptionDemandeVueModel> _ListeDemandeOptions;
        public ObservableCollection<OptionDemandeVueModel> ListeDemandeOptions
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

        private OptionDemandeVueModel _CurrentSelectionOptionDem;
        public OptionDemandeVueModel CurrentSelectionOption
        {
            get
            {
                return _CurrentSelectionOptionDem;
            }
            set
            {
                _CurrentSelectionOptionDem = value;
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
            UpdateListeChambresHotel();
            observerChambre = CollectionViewSource.GetDefaultView(ListeChambresHotel);
            observerChambre.CurrentChanged += CurrentReservationChanged;
            if (NumeroChambre != 0)
            {
                observerChambre.MoveCurrentTo((from c in ListeChambresHotel where c.Numero == NumeroChambre select c).Single<ChambreViewModel>());
            }
            OptionService osrv = Services.OptionService.Instance;
            List<DemandeOption> dOption = osrv.getOptionDemande(cr.Id);
            ListeDemandeOptions = new ObservableCollection<OptionDemandeVueModel>();
            foreach (DemandeOption optionD in dOption)
            {
                OptionDemandeVueModel oDvm = new OptionDemandeVueModel(optionD);
                oDvm.suppresion += SupprimerOption;
                ListeDemandeOptions.Add(oDvm);
            }
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
                ID = Srv.AddChambreReservee(ChambreReservee);
                foreach (OptionDemandeVueModel option in ListeDemandeOptions)
                {
                    option.idCHambreR = ID;
                }
            }
            else
            {
                Srv.UpdateChambreReservee(ChambreReservee);
            }
            EnregistrerOption();
        }
        private void EnregistrerOption()
        {
            foreach (OptionDemandeVueModel demandeVueModel in ListeDemandeOptions)
            {
                demandeVueModel.Enregistrer();
            }
        }

        #endregion
        #region "Gestion des options"
        public ICommand AddOption
        {
            get
            {
                return new RelayCommand(addOption);
            }
        }
        private void addOption()
        {
            DemandeOption dOpt = new DemandeOption();
            dOpt.NbJour = 0;
            dOpt.IdChambreReservee = ID;
            OptionDemandeVueModel optVM = new OptionDemandeVueModel(dOpt);
            optVM.suppresion += SupprimerOption;
            ListeDemandeOptions.Add(optVM);
            NotifyPropertyChanged();
        }
        #endregion

        private ObservableCollection<ChambreViewModel> _listeChambresHotel;

        public ObservableCollection<ChambreViewModel> ListeChambresHotel
        {
            get { return _listeChambresHotel; }
            set { _listeChambresHotel = value; }
        }

        private readonly ICollectionView observerChambre;


        private void UpdateListeChambresHotel()
        {
            ListeChambresHotel = new ObservableCollection<ChambreViewModel>();
            ChambreService srv = new ChambreService();
            List<Chambre> AllChambres = srv.GetAllChambres();

            foreach (Chambre c in AllChambres)
            {
                ChambreViewModel newChambre = new ChambreViewModel(srv, c);
                ListeChambresHotel.Add(newChambre);
            }
        }

        private void CurrentReservationChanged(object sender, EventArgs e)
        {
            if (observerChambre.CurrentItem != null)
            {
                ChambreViewModel c = observerChambre.CurrentItem as ChambreViewModel;
                NumeroChambre = c.Numero;
            }
        }       
        private void SupprimerOption(object sender, EventArgs args)
        {
            if (sender != null)
            {
                ListeDemandeOptions.Remove(sender as OptionDemandeVueModel);
            }
        }
        public double UpdatePrix(int nbNuits)
        {
            double prix = 0;
            foreach (OptionDemandeVueModel option in ListeDemandeOptions)
            {
                prix += option.UpdatePrix();
            }
            int nbDizaine = nbNuits / 10;
            int reste = nbNuits % 10;
            int nbCinq = reste / 5;
            reste = nbNuits % 5;
            prix += Srv.calculPrix(ChambreReservee.Id, nbDizaine, nbCinq, reste);
            return prix;
        }
    }
}
