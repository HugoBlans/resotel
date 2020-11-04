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

namespace ProjetRESOTEL.ViewModels
{
    public class ListReservationModel : ViewModelBase
    {
        private ReservationService srv;
        private ObservableCollection<KeyValuePair<Reservation, Entities.Client>> _dicoResCli;

        public ObservableCollection<KeyValuePair<Reservation, Entities.Client>> ListeResCli
        {
            get { return _dicoResCli; }
            set
            {
                _dicoResCli = value;
                NotifyPropertyChanged(nameof(ListeResCli));
            }
        }

        // Observateur de la liste observable
        private readonly ICollectionView observer;

        public ListReservationModel()
        {
            srv = ReservationService.Instance;
            ListeResCli = srv.chargerListResa();
            observer = CollectionViewSource.GetDefaultView(ListeResCli);

            // TODO Comme Nadine pour observer les changements de l'élément courrrant
            //ajoute l'événement qui notifie que la sélection a changer dans la vue
            //observer.CurrentChanged += Observer_CurrentChanged;
            observer.CurrentChanged += Observer_CurrentChanged;

            observer.MoveCurrentToFirst();
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ReservationSelected");
        }

        public ReservationModel ReservationSelected
        {
            get
            {
                return observer.CurrentItem as ReservationModel;
            }
        }
    }
}
