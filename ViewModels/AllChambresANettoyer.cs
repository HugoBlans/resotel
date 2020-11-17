using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.ViewModels;

namespace ProjetRESOTEL.ViewModels
{
    public class AllChambresANettoyer : ViewModelBase
    {
        private ObservableCollection<ChambreANettoyerViewModel> _listChambresE1;

        public ObservableCollection<ChambreANettoyerViewModel> ListChambresE1
        {
            get { return _listChambresE1; }
            set { _listChambresE1 = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<ChambreANettoyerViewModel> _listChambresE2;

        public ObservableCollection<ChambreANettoyerViewModel> ListChambresE2
        {
            get { return _listChambresE2; }
            set { _listChambresE2 = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<ChambreANettoyerViewModel> _listChambresE3;

        public ObservableCollection<ChambreANettoyerViewModel> ListChambresE3
        {
            get { return _listChambresE3; }
            set { _listChambresE3 = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<ChambreANettoyerViewModel> _listChambresE4;

        public ObservableCollection<ChambreANettoyerViewModel> ListChambresE4
        {
            get { return _listChambresE4; }
            set { _listChambresE4 = value; NotifyPropertyChanged(); }
        }

        private ChambresANettoyerService Srv;
        public AllChambresANettoyer(ChambresANettoyerService srv)
        {
            Srv = srv;

            ListChambresE1 = new ObservableCollection<ChambreANettoyerViewModel>();
            ListChambresE2 = new ObservableCollection<ChambreANettoyerViewModel>();
            ListChambresE3 = new ObservableCollection<ChambreANettoyerViewModel>();
            ListChambresE4 = new ObservableCollection<ChambreANettoyerViewModel>();
            UpdateListChambre(0);
        }

        private void UpdateListChambre(int etage)
        {
            List<Chambre> ChambresAFaire = null;
            switch (etage)
            {
                case 0:
                    UpdateListChambre(1);
                    UpdateListChambre(2);
                    UpdateListChambre(3);
                    UpdateListChambre(4);
                    break;
                case 1:
                    ChambresAFaire = Srv.getChambresANettoyer(1);
                    foreach (Chambre chambre in ChambresAFaire)
                    {
                        ChambreANettoyerViewModel vm = new ChambreANettoyerViewModel(chambre, Srv);
                        vm.ChambreNettoyee += Vm_ChambreNettoyee;
                        ListChambresE1.Add(vm);
                    }
                    break;
                case 2:
                    ChambresAFaire = Srv.getChambresANettoyer(2);
                    foreach (Chambre chambre in ChambresAFaire)
                    {
                        ChambreANettoyerViewModel vm = new ChambreANettoyerViewModel(chambre, Srv);
                        vm.ChambreNettoyee += Vm_ChambreNettoyee;
                        ListChambresE2.Add(vm);
                    }
                    break;
                case 3:
                    ChambresAFaire = Srv.getChambresANettoyer(3);
                    foreach (Chambre chambre in ChambresAFaire)
                    {
                        ChambreANettoyerViewModel vm = new ChambreANettoyerViewModel(chambre, Srv);
                        vm.ChambreNettoyee += Vm_ChambreNettoyee;
                        ListChambresE3.Add(vm);
                    }
                    break;
                case 4:
                    ChambresAFaire = Srv.getChambresANettoyer(4);
                    foreach (Chambre chambre in ChambresAFaire)
                    {
                        ChambreANettoyerViewModel vm = new ChambreANettoyerViewModel(chambre, Srv);
                        vm.ChambreNettoyee += Vm_ChambreNettoyee;
                        ListChambresE4.Add(vm);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Vm_ChambreNettoyee(object sender, EventArgs e)
        {
            ChambreANettoyerViewModel chambre = sender as ChambreANettoyerViewModel;
            switch (chambre.NumeroEtage)
            {
                case 1:
                    ListChambresE1.Remove(sender as ChambreANettoyerViewModel);
                    NotifyPropertyChanged("ListChambresE1");
                    break;
                case 2:
                    ListChambresE2.Remove(sender as ChambreANettoyerViewModel);
                    NotifyPropertyChanged("ListChambresE2");
                    break;
                case 3:
                    ListChambresE3.Remove(sender as ChambreANettoyerViewModel);
                    NotifyPropertyChanged("ListChambresE3");
                    break;
                case 4:
                    ListChambresE4.Remove(sender as ChambreANettoyerViewModel);
                    NotifyPropertyChanged("ListChambresE4");
                    break;
                default:
                    break;
            }
        }
    }
}
