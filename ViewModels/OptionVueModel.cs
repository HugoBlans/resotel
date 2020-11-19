using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class OptionVueModel : ViewModelBase
    {
        private OptionService service;
        private Option _opt;
        public Option opt
        {
            get { return _opt; }
            set { _opt = value; NotifyPropertyChanged(); }
        }
        public OptionVueModel(Option opt)
        {
            service = Services.OptionService.Instance;
            _opt = opt;
        }
        public override string ToString()
        {
            return opt.Designation;
        }
    }
}
