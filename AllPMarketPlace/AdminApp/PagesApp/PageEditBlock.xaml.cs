using AdminApp.ADOApp;
using AdminApp.ClassApp;
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
    /// Логика взаимодействия для PageEditBlock.xaml
    /// </summary>
    public partial class PageEditBlock : Page
    {
        public PageEditBlock()
        {
            InitializeComponent();
            defolt();
        }
        public void defolt()
        {
            ListBLock.ItemsSource = App.Connection.UsersPM.Where(z => z.IsBlock == true).ToList();
            
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ListBLock.SelectedItem != null)
            {
                var SelUser = ListBLock.SelectedItem as UsersPM;
                SelUser.IsBlock = false;
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal($"пользователь ~{SelUser.Users.FullName}~ снят блокировки");
                defolt();
            }

        }
    }
}
