using ProjetRESOTEL.Views;
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

namespace ProjetRESOTEL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void btnNewReservation_Checked(object sender, RoutedEventArgs e)
        {
           TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucNewReservation();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

        private void btnListReservation_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucListReservation();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }
        private void btnWeekCalendar_Click(object sender,RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear();
            var userControle = new ucPlanningSemaine();
            _tabUserPage = new TabItem { Content = userControle };
            MainTab.Items.Add(_tabUserPage);
            MainTab.Items.Refresh();
        }
        private void btnListClient_Click_1(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucListClient();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

        private void btnListMenages_Click_1(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucMenages();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls 
            MainTab.Items.Refresh();
        }

        private void btnAddMeal_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear();
            var userControls = new ucNewRepas();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage);
            MainTab.Items.Refresh();
        }
    }
}
