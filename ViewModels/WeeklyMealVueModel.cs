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
    class WeeklyMealVueModel :ViewModelBase
    {
        private RepasService serv;
        private DateTime curDate;
        private List<RepasJour> _allMeal;
        public List<RepasJour> allMeal
        {
            get
            {
                return _allMeal;
            }
        }
        public WeeklyMealVueModel()
        {
            serv = Services.RepasService.Instance;
            curDate = System.DateTime.Now;
            _allMeal = serv.chargerRepasHebdo(curDate);
        }
        public int NbRepasMatin
        {
            get
            {
                int repasMatinCount = 0;
                foreach(RepasJour repas in _allMeal)
                {
                    repasMatinCount += repas.nbRepasMatin;
                }
                return repasMatinCount;
            }
        }
        public int NbRepasMidi
        {
            get
            {
                int repasMidiCount = 0;
                foreach (RepasJour repas in _allMeal)
                {
                    repasMidiCount += repas.nbRepasMidi;
                }
                return repasMidiCount;
            }
        }
        public ICommand previous
        {
            get
            {
                return new RelayCommand(Previous);
            }
        }
        private void Previous()
        {
            _allMeal.Clear();
            curDate = curDate.AddDays(-1);
            _allMeal = serv.chargerRepasHebdo(curDate);
            NotifyPropertyChanged("allMeal");
        }
        public ICommand next
        {
            get
            {
                return new RelayCommand(Next);
            }
        }
        private void Next()
        {
            _allMeal.Clear();
            curDate = curDate.AddDays(1);
            _allMeal = serv.chargerRepasHebdo(curDate);
            NotifyPropertyChanged("allMeal");
        }
    }
}
