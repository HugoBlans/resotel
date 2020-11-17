using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using ProjetRESOTEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class ChambreANettoyerViewModel : ViewModelBase
    {
        private Chambre _chambreANet;

        public Chambre ChambreANet
        {
            get { return _chambreANet; }
            set {
                _chambreANet = value;
                NotifyPropertyChanged();
            }
        }

        public int Numero
        {
            get
            {
                return ChambreANet.Numero;
            }
        }

        public int NumeroEtage
        {
            get
            {
                return ChambreANet.NumEtage;
            }
        }



        public ChambresANettoyerService Srv { get; set; }

        public ChambreANettoyerViewModel(Chambre cn, ChambresANettoyerService srv)
        {
            Srv = srv;
            ChambreANet = cn;
        }


        public event EventHandler ChambreNettoyee;

        private RelayCommand _estNettoyee;

        public RelayCommand EstNettoyee
        {
            get
            {
                if (_estNettoyee == null)
                {
                    _estNettoyee = new RelayCommand(chambreUpdateNettoyage);
                }
                return _estNettoyee;
            }
        }

        private void chambreUpdateNettoyage()
        {
            Srv.ChambreEstNettoyee(ChambreANet.Numero);
            ChambreNettoyee?.Invoke(this, EventArgs.Empty);
        }
    }
}
