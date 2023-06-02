using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
using SalesManApp.PagesApp;

namespace SalesManApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAtho());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAppeals.PagesAppealS());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAddProduct());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAddGall());
        }
    }
}
