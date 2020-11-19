using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public ClientsService Srv { get; set; }
        private Client _client;

        public Client Client
        {
            get { return _client; }
            set 
            { 
                _client = value;
                NotifyPropertyChanged();
            }
        }

        public int ID
        {
            get { return Client.IdentifiantCli; }
            set 
            {
                Client.IdentifiantCli = value;
                NotifyPropertyChanged();
            }
        }

        public string Nom
        {
            get { return Client.Nom; }
            set
            {
                Client.Nom = value;
                NotifyPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return Client.Prenom; }
            set 
            { 
                Client.Prenom = value; 
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return Client.Email; }
            set 
            { 
                Client.Email = value;
                NotifyPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return Client.Telephone; }
            set 
            {
                Client.Telephone = value;
                NotifyPropertyChanged();
            }
        }

        public event EventHandler ClientDeleted;

        private RelayCommand _delete;

        public RelayCommand Delete
        {
            get
            {
                if (_delete == null)
                {
                    _delete = new RelayCommand(DeleteExcecute);
                }
                return _delete;
            }
        }

        private void DeleteExcecute()
        {
            Srv.RemoveClient(Client.IdentifiantCli);
            ClientDeleted?.Invoke(this, EventArgs.Empty);
        }


        private RelayCommand _update;

        public RelayCommand Update
        {
            get
            {
                if (_update == null)
                {
                    _update = new RelayCommand(UpdateExcecute);
                }
                return _update;
            }
        }

        private void UpdateExcecute()
        {
            Srv.UpdateClient(Client);
        }

        public ClientViewModel(ClientsService srvCli, Client cli)
        {
            Srv = srvCli;
            Client = cli;
        }

        public event EventHandler ClientAdded;

        private RelayCommand _enregistrer;


        public RelayCommand Enregistrer
        {
            get
            {
                if (_enregistrer == null)
                {
                    _enregistrer = new RelayCommand(EnregistrerExcecute, EnregistrerCanExcecute);
                }
                return _enregistrer;
            }
        }

        private bool EnregistrerCanExcecute()
        {
            if (Nom != null && Prenom != null && Email != null && Telephone != null)
            {
                return true;
            }
            return false;
        }

        private void EnregistrerExcecute()
        {
            ID = Srv.AddClient(Client);
            ClientAdded?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
