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
    public class ReservationViewModel : ViewModelBase   
    {
        public ReservationService Srv;

        #region "Colonnes table"
        private Reservation _reservation;

        public Reservation Reservation
        {
            get { return _reservation; }
            set { _reservation = value; NotifyPropertyChanged(); }
        }

        public int NbNuits
        {
            get
            {
                return Reservation.NbNuits;
            }
            set
            {
                Reservation.NbNuits = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? DateDebutSejour {
        get
            {
                return Reservation.DateDebutSejour;
            }
        set
            {
                Reservation.DateDebutSejour = value;
                NotifyPropertyChanged();
            }
        }

        public int ID
        {
            get
            {
                return Reservation.IdentifiantRes;
            }
            set
            {
                Reservation.IdentifiantRes = value;
                NotifyPropertyChanged();
            }
        }

        public int IDCli
        {
            get
            {
                return Reservation.IdentifiantCli;
            }
            set
            {
                Reservation.IdentifiantCli = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        // liason table client
        private ClientViewModel _client;

        public ClientViewModel Client
        {
            get { return _client; }
            set { _client = value; NotifyPropertyChanged(); }
        }



        //liaison table chambres réservées associées
        public ObservableCollection<ChambreReserveeViewModel> ListeChambreReservees { get; set; }
        private readonly ICollectionView observerChambres;


        public ReservationViewModel(ReservationService srv,Reservation resa)
        {
            Reservation = resa;
            Srv = srv;
            ListeChambreReservees = new ObservableCollection<ChambreReserveeViewModel>();
            if (ID != 0)
            {
                GetClientResa();
                GetChambresReservees();
            }
            observerChambres = CollectionViewSource.GetDefaultView(ListeChambreReservees);
            observerChambres.CurrentChanged += CurrentChambreChanged;
            observerChambres.MoveCurrentToFirst();
        }

        private void CurrentChambreChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("CurrentChambreSelected");
        }

        public ChambreReserveeViewModel CurrentChambreSelected
        {
            get { return observerChambres.CurrentItem as ChambreReserveeViewModel; }
        }

        private void GetChambresReservees()
        {
            List<ChambreReservee> lcr = Srv.GetChambresReservées(ID);
            ChambreReserveeService crSrv = new ChambreReserveeService();
            foreach (ChambreReservee cr in lcr)
            {
                ChambreReserveeViewModel crVM = new ChambreReserveeViewModel(crSrv, cr);
                crVM.ChambreReserveeSupprimee += ChambreReserveeSupprimee;
                ListeChambreReservees.Add(crVM);
            }
        }

        private void ChambreReserveeSupprimee(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ListeChambreReservees.Remove(sender as ChambreReserveeViewModel);
                NotifyPropertyChanged("ListeChambreReservees");
            }
        }

        private void GetClientResa()
        {
            var srvCli = new ClientsService();
            Client cli = srvCli.GetClient(IDCli);
            Client = new ClientViewModel(srvCli, cli);
        }

        #region "Commandes"
        private RelayCommand _commandeNouvelleChambreReservee;
        public ICommand CommandeNouvelleChambreReservee
        {
            get
            {
                if (_commandeNouvelleChambreReservee == null)
                {
                    _commandeNouvelleChambreReservee = new RelayCommand(NouvelleChambreReservee);
                }
                return _commandeNouvelleChambreReservee;
            }
        }

        private void NouvelleChambreReservee()
        {
            ChambreReserveeService srvCR = new ChambreReserveeService();
            ChambreReserveeViewModel vm = new ChambreReserveeViewModel(srvCR, new ChambreReservee());
            vm.ChambreReserveeSupprimee += ChambreReserveeSupprimee;
            ListeChambreReservees.Add(vm);

            observerChambres.MoveCurrentTo(vm);
            NotifyPropertyChanged("ListeChambreReservees");
        }

        private RelayCommand _commandeSupprimerReservation;
        public ICommand CommandeSupprimerReservation
        {
            get
            {
                if (_commandeSupprimerReservation == null)
                {
                    _commandeSupprimerReservation = new RelayCommand(SupprimerReservation);
                }
                return _commandeSupprimerReservation;
            }
        }
        public event EventHandler ReservationSupprimee;
        // Suppression
        public void SupprimerReservation()
        {
            if (ID != 0)
            {
                Srv.RemoveReservation(ID);
            }
            ReservationSupprimee?.Invoke(this, EventArgs.Empty);
        }

        private RelayCommand _commandeEnregistrerReservation;
        public ICommand CommandeEnregistrerReservation
        {
            get
            {
                if (_commandeEnregistrerReservation == null)
                {
                    _commandeEnregistrerReservation = new RelayCommand(EnregistrerReservation, CanEnregistrerReservation);
                }
                return _commandeEnregistrerReservation;
            }
        }

        private bool CanEnregistrerReservation()
        {
            if (Client != null && DateDebutSejour !=null  &&  NbNuits > 0)
            {
                return true;
            }
            return false;
        }

        public event EventHandler ReservationEnregistree;
        // Suppression
        public void EnregistrerReservation()
        {
            if (Client != null)
            {
                Reservation.IdentifiantCli = Client.ID;
                if (ID == 0)
                {
                    ID = Srv.AddReservation(Reservation);
                }
                else
                {
                    Srv.UpdateReservation(Reservation);
                }

                EnregistrerChambresReservees();
                ReservationEnregistree?.Invoke(this, EventArgs.Empty);
            }

        }
        #endregion

        private void EnregistrerChambresReservees()
        {
            foreach (ChambreReserveeViewModel cr in ListeChambreReservees)
            {
                cr.IdRes = ID;
                cr.EnregistrerChambreReservee();
            }
        }
    }
}
