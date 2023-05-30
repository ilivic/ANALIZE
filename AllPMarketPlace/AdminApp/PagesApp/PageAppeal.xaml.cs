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
using AdminApp.ADOApp;
using AdminApp.ClassApp;
using AdminApp.WindowsApp;

namespace AdminApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageAppeal.xaml
    /// </summary>
    public partial class PageAppeal : Page
    {
        public PageAppeal()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            ListAppeal.ItemsSource = App.Connection.Appeal.Where(z=>z.TypeAppeal_id != 3).ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListAppeal.SelectedItem != null && TxtMessage.Text!="")
            {
                var SelAppeal = ListAppeal.SelectedItem as Appeal;
                Answer NewAnswer = new Answer()
                {
                    Appeal_id =SelAppeal.id_Appeal,
                    Text = TxtMessage.Text,
                    DateCreate= DateTime.Now,
                    User_id = ClassAllMethod.CorrUser.id_User,
                };
                App.Connection.Answer.Add(NewAnswer);
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal("Сообщение отправлено");
            }
            else
            {
                ClassAllMethod.MessageError("Не все поля заполнены или не выбрана заявка");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListAppeal.SelectedItem != null)
            {
                var SelType = ListAppeal.SelectedItem as Appeal;
                WindowEditStatus window = new WindowEditStatus(SelType);
                window.ShowDialog();
                refresh();
            }
        }
    }
}
