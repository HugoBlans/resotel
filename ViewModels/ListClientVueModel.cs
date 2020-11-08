using ProjetRESOTEL.Entities;
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
    class ListClientVueModel : ViewModelBase
    {
        #region Declare
        private readonly ObservableCollection<NewClientVueModel> listeClients;

        public ObservableCollection<NewClientVueModel> ListeClients
        {
            get
            {
                return listeClients;
            }
        }

        private readonly ICollectionView observer;
        #endregion

        #region Constructeur
        public ListClientVueModel()
        {
            List<Client> lst = Services.ClientService.Instance.ChargerClients();

            listeClients = new ObservableCollection<NewClientVueModel>();
            foreach (Client cli in lst)
            {
                NewClientVueModel vm = new NewClientVueModel(cli);
                vm.EventSupprimer += Vm_EventSupprimer;
                listeClients.Add(vm);
            }
            //lier l'observer à la liste
            observer = CollectionViewSource.GetDefaultView(listeClients);

            //ajoute l'événement qui notifie que la sélection a changer dans la vue
            observer.CurrentChanged += Observer_CurrentChanged;

            observer.MoveCurrentToLast();
        }

        private void Vm_EventSupprimer(object sender, EventArgs e)
        {
            listeClients.Remove(sender as NewClientVueModel);
            NotifyPropertyChanged("ListeClients");
        }
        #endregion

        #region Events
        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ClientSelected");
        }
        #endregion

        #region Methodes
        public NewClientVueModel ClientSelected
        {
            get
            {
                return observer.CurrentItem as NewClientVueModel;
            }
        }
        #endregion


        #region Commandes
        private RelayCommand commandeNouveau;
        public ICommand NouveauCommande
        {
            get
            {
                if (commandeNouveau == null)
                {
                    commandeNouveau = new RelayCommand(NouveauClient);
                }
                return commandeNouveau;
            }
        }

        private void NouveauClient()
        {
            NewClientVueModel vm = null;
            vm = new NewClientVueModel(new Client());
            vm.EventSupprimer += Vm_EventSupprimer;
            listeClients.Add(vm);

            observer.MoveCurrentToLast();
            NotifyPropertyChanged("ListeClients");
        }
        #endregion

        #region Recherche
        //Récupération du texte saisi
        public string TexteRechercher
        {
            set
            {
                observer.Filter = item => IsMatch(item, value);
                NotifyPropertyChanged("TexteRechercherNoMatch");
            }
        }

        //Si recherche vide
        public bool TexteRechercherNoMatch
        {
            get { return observer.IsEmpty;  }
        }

        //Méthode déterminant si l'élément correspond à la recherche
        private bool IsMatch(object item, string value)
        {
            if (!(item is NewClientVueModel))
            {
                return false;
            }
            value = value.ToUpper();
            NewClientVueModel p = (NewClientVueModel)item;
            return (p.Client.Nom.ToUpper().Contains(value)
                || p.Client.Prenom.ToUpper().Contains(value));
        }
        #endregion
    }
}
