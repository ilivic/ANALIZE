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
using AdminApp.ClassApp;
using AdminApp.WindowsApp;

namespace AdminApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageAutho.xaml
    /// </summary>
    public partial class PageAutho : Page
    {
        public PageAutho()
        {
            InitializeComponent();
        }

        private void CLEventRegistraion(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }

        private void ClEventAuthorization(object sender, RoutedEventArgs e)
        {
            if (TxtLogin.Text!="" && TxtPassword.Password!="")
            {
                var Reation = ClassAllMethod.Authorization(TxtLogin.Text, TxtPassword.Password);
                if (Reation == true)
                {
                    WindowSplah window = new WindowSplah();
                    window.ShowDialog();
                    NavigationService.Navigate(new PageMenu());
                }
            }

        }
    }
}
