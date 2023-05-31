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
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;

namespace SalesManApp.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateAppeal.xaml
    /// </summary>
    public partial class WindowCreateAppeal : Window
    {

        public WindowCreateAppeal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtText.Text != "")
            {
                Appeal NewAppeal = new Appeal()
                {
                    Text= TxtText.Text,
                    TypeAppeal_id = 1,
                    DataCreate = DateTime.Now,
                    User_id = ClassAllMethod.CorrUser.id_User
                };
                App.Connection.Appeal.Add(NewAppeal);
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal("Сообщение будет отправлено)");
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
