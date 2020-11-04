using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    class NewClientVueModel : ViewModelBase
    {
        private Client client;

        public Client Client
        {
            get { return client; }
        }

        public NewClientVueModel(Client cli)
        {
            if (cli == null)
            {
                throw new NullReferenceException("Client");
            }
            client = cli;
        }

        public string Nom
        {
            get { return client.Nom; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    client.Nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Prenom
        {
            get { return client.Prenom; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {

                    client.Prenom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region Enregister Client
        public ICommand CommandeEnregistrer
        {
            get
            {
                return new RelayCommand(Enregistrer);
            }
        }

        private void Enregistrer()
        {
            client = ClientService.Instance.Enregistrer(client);

        }


        private bool CanEnregistrer()
        {
            if (string.IsNullOrWhiteSpace(client.Nom))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(client.Prenom))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Supprimer Client
        public event EventHandler EventSupprimer;

        public ICommand CommandeSupprimer
        {
            get
            {
                return new RelayCommand(Supprimer);
            }
        }

        private void Supprimer()
        {
            if (ClientService.Instance.Supprimer(client))
            {
                EventSupprimer?.Invoke(this, EventArgs.Empty);
            }

        }
        #endregion

    }
}
