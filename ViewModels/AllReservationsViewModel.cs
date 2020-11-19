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
    class AllReservationsViewModel : ViewModelBase
    {
        private ObservableCollection<ReservationViewModel> _listeReservations;

        public ObservableCollection<ReservationViewModel> ListeReservations
        {
            get { return _listeReservations; }
            set { _listeReservations = value; }
        }

        public ReservationViewModel CurrentReservation
        {
            get { return observer.CurrentItem as ReservationViewModel; }
        }

        public ReservationService Srv { get; set; }

        private readonly ICollectionView observer;

        public AllReservationsViewModel()
        {
            Srv = new ReservationService();
            ListeReservations = new ObservableCollection<ReservationViewModel>();
            ListeChoixClient = new ObservableCollection<ClientViewModel>();
            UpdateListChoixClient();
            UpdateListReservation();
            observer = CollectionViewSource.GetDefaultView(ListeReservations);
            observer.CurrentChanged += CurrentReservationChanged;
            observer.MoveCurrentToFirst();
        }

        private void CurrentReservationChanged(object sender, EventArgs e)
        {

            if (CurrentReservation != null && CurrentReservation.ID !=0)
            {
                CurrentReservationClient = (from cli in ListeChoixClient where cli.ID == CurrentReservation.IDCli select cli).Single<ClientViewModel>();
            } else
            {
                CurrentReservationClient = null;
            }
            NotifyPropertyChanged("CurrentReservation");
            
        }

        private void UpdateListReservation()
        {
            List<Reservation> AllResa = Srv.GetReservations();

            foreach (Reservation resa in AllResa)
            {
                ReservationViewModel newResa = new ReservationViewModel(Srv, resa);
                newResa.ReservationSupprimee += SupprimerReservation;
                ListeReservations.Add(newResa);
            }
        }

        private void SupprimerReservation(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ListeReservations.Remove(sender as ReservationViewModel);
            }
        }

        private ObservableCollection<ClientViewModel> _listeChoixClient;

        public ObservableCollection<ClientViewModel> ListeChoixClient
        {
            get { return _listeChoixClient; }
            set { _listeChoixClient = value; }
        }


        public ClientViewModel CurrentReservationClient
        {
            get 
            {
                if (CurrentReservation != null)
                {
                    return CurrentReservation.Client;
                }
                return null;
            }
            set 
            {
                if (CurrentReservation != null)
                {
                    CurrentReservation.Client = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void UpdateListChoixClient()
        {
            ClientsService srvCli = new ClientsService();
            List<Client> AllCli = srvCli.GetAllClients();

            foreach (Client cli in AllCli)
            {
                ClientViewModel newCli = new ClientViewModel(srvCli, cli);
                ListeChoixClient.Add(newCli);
            }
        }

        #region "Commandes
        private RelayCommand _commandeNouvelleResa;
        public ICommand CommandeNouvelleResa
        {
            get
            {
                if (_commandeNouvelleResa == null)
                {
                    _commandeNouvelleResa = new RelayCommand(NouvelleResa);
                }
                return _commandeNouvelleResa;
            }
        }
        private void NouvelleResa()
        {
            ReservationViewModel vm = new ReservationViewModel(Srv, new Reservation());
            //vm.EventSupprimer += Vm_EventSupprimer;
            ListeReservations.Add(vm);

            observer.MoveCurrentTo(vm);
            
            NotifyPropertyChanged("ListeReservations");
        }
        #endregion
    }
}
