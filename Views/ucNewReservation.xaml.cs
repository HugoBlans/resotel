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
using Xceed.Wpf.Toolkit;

namespace ProjetRESOTEL.Views
{
    /// <summary>
    /// Logique d'interaction pour ucNewReservation.xaml
    /// </summary>
    public partial class ucNewReservation : UserControl
    {
        public ucNewReservation()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void addRoom_Click(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = new ComboBox(); // Création d'un nouveau combo box
            cmb.Items.Add("Chambre Individuelle");
            cmb.Items.Add("Chambre Double");
            cmb.Items.Add("Chambre 3 personnes");
            cmb.Items.Add("Chambre 4 personnes");
            cmb.Items.Add("Chambre 6 personnes");
            cmb.Items.Add("Chambre Double + Bébé");

            panelComboBox.Children.Add(cmb); // Ajout du combo box dans le stackpanel
        }

        private void checkCardio_Checked(object sender, RoutedEventArgs e)
        {
            SingleUpDown sgl = new SingleUpDown();
            sgl.Value = 1;
            sgl.Increment = 1;
            SolidColorBrush transp = new SolidColorBrush();
            sgl.Background = transp;
            sgl.BorderBrush = transp;
            SolidColorBrush white = new SolidColorBrush(Colors.White);
            sgl.Foreground = white;
            optCardio.Children.Add(sgl);
        }

        private void checkCardio_Unchecked(object sender, RoutedEventArgs e)
        {
            if (optCardio.Children.Count > 0)
            {
                optCardio.Children.RemoveAt(optCardio.Children.Count - 1);
            }
        }
    }
}
