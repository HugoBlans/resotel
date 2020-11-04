using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetRESOTEL.Views
{
    /// <summary>
    /// Logique d'interaction pour ucListClient.xaml
    /// </summary>
    public partial class ucListClient : UserControl
    {
        public ucListClient()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.ListClientVueModel();
        }
    }
}
