using ProjetRESOTEL.ViewModels;
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
using System.Windows.Shapes;

namespace ProjetRESOTEL.Views
{
    /// <summary>
    /// Logique d'interaction pour NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        private ClientViewModel VM;
        public NewClient()
        {
            InitializeComponent();

        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
            {
                VM = DataContext as ClientViewModel;
                VM.ClientAdded += CloseWindow;
            }
        }
    }
}
