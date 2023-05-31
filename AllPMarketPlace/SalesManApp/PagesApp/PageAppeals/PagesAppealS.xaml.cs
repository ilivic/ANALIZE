using SalesManApp.ADOApp;
using SalesManApp.ClassApp;
using SalesManApp.WindowsApp;
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

namespace SalesManApp.PagesApp.PageAppeals
{
    /// <summary>
    /// Логика взаимодействия для PagesAppealS.xaml
    /// </summary>
    public partial class PagesAppealS : Page
    {
        public PagesAppealS()
        {
            InitializeComponent();
            refresh();
        }
        public static List<Appeal> ListAppeal { get; set; }


        public void refresh()
        {
            ListAppeal = new List<Appeal>(App.Connection.Appeal.Where(z => z.User_id == ClassAllMethod.CorrUser.id_User).ToList());
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCreateAppeal window = new WindowCreateAppeal();
            window.ShowDialog();
            refresh();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListAppeall.SelectedItem != null)
            {
                var SelAppeal = ListAppeall.SelectedItem as Appeal;
                MainAnswerFrame.NavigationService.Navigate(new PageAppeal.PageAnswers(SelAppeal));
            }
        }
    }
}
