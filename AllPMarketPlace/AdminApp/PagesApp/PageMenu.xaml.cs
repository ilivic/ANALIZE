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

namespace AdminApp.PagesApp
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
            NavigationService.Navigate(new PageAutho());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAddCat());

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAppeal());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageAddProductMaker());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainNaviFarame.NavigationService.Navigate(new PageEditBlock());
        }
    }
}
