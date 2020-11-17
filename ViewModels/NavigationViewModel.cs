using ProjetRESOTEL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetRESOTEL.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {

        private ObservableCollection<UserControl> _listPages;

        public ObservableCollection<UserControl> ListPages
        {
            get { return _listPages; }
            set
            {
                _listPages = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _currentPage;

        public UserControl CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyPropertyChanged();
            }
        }

        public NavigationViewModel()
        {
            ListPages = new ObservableCollection<UserControl>();
            //Accueil acc = new Accueil();
            //ListPages.Add(acc);
            //CurrentPage = acc;
        }

        private RelayCommand _navigation;

        public RelayCommand Navigation
        {
            get
            {
                if (_navigation == null)
                {
                    _navigation = new RelayCommand(goAccueil);
                }
                return _navigation;
            }
        }

        private void goAccueil(object dest)
        {
            UserControl destUC = null;
            switch ((string)dest)
            {
                case "clients":
                    destUC = ListPages.FirstOrDefault(x => x is ucListClient);
                    if (destUC == null) destUC = new ucListClient();
                    break;
                case "réservations":
                    destUC = ListPages.FirstOrDefault(x => x is ucReservations);
                    if (destUC == null) destUC = new ucReservations();
                    break;
                case "planningRepas":
                    destUC = ListPages.FirstOrDefault(x => x is ucPlanningSemaine);
                    if (destUC == null) destUC = new ucPlanningSemaine();
                    break;
                case "ajoutRepas":
                    destUC = ListPages.FirstOrDefault(x => x is ucNewRepas);
                    if (destUC == null) destUC = new ucNewRepas();
                    break;
                case "ménages":
                    destUC = ListPages.FirstOrDefault(x => x is ucMenages);
                    if (destUC == null) destUC = new ucMenages();
                    break;


            }

            CurrentPage = destUC;
        }
    }
}
