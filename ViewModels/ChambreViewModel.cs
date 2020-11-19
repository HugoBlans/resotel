using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class ChambreViewModel : ViewModelBase
    {
        private Chambre _chambre;

        public Chambre Chambre
        {
            get { return _chambre; }
            set 
            { 
                _chambre = value;
                NotifyPropertyChanged();
            }
        }

        public int Numero
        {
            get { return Chambre.Numero; }
            set 
            { 
                Chambre.Numero = value;
                NotifyPropertyChanged();
            }
        }

        public int NumEtage
        {
            get { return Chambre.NumEtage; }
            set 
            {
                Chambre.NumEtage = value;
                NotifyPropertyChanged();
            }
        }

        private int _nbLit;

        public int NbLit
        {
            get { return Chambre.NbLit; }
            set 
            { 
                Chambre.NbLit = value;
                NotifyPropertyChanged();
            }
        }

        public bool LitEnfant
        {
            get { return Chambre.LitEnfant; }
            set
            {
                Chambre.LitEnfant = value;
                NotifyPropertyChanged();
            }
        }

        public bool LitDouble
        {
            get { return Chambre.LitDouble; }
            set 
            { 
                Chambre.LitDouble = value;
                NotifyPropertyChanged();
            }
        }

        private ChambreService Srv;

        public event EventHandler ChambreDeleted;

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
            Srv.RemoveChambre(Chambre.Numero);
            ChambreDeleted?.Invoke(this, EventArgs.Empty);
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
            Srv.UpdateChambre(Chambre);
        }

        public ChambreViewModel(ChambreService ChSrv, Chambre ch)
        {
            Srv = ChSrv;
            Chambre = ch;
        }

        public override string ToString()
        {
            return "Etage n°" + NumEtage + " Chambre " + Numero;
        }

    }
}
