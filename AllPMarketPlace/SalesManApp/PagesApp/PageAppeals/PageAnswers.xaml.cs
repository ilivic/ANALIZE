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
using SalesManApp.ClassApp;
using SalesManApp.ADOApp;

namespace SalesManApp.PagesApp.PageAppeal
{
    /// <summary>
    /// Логика взаимодействия для PageAnswers.xaml
    /// </summary>
    public partial class PageAnswers : Page
    {
        public static Appeal selAppeal { get; set; }
        public PageAnswers(Appeal SelAppeal)
        {
            InitializeComponent();
            selAppeal= SelAppeal;
            refresh();
        }
        public void refresh()
        {
            this.DataContext = selAppeal;
            ListAnswer.ItemsSource = App.Connection.Answer.Where(z=>z.Appeal_id == selAppeal.id_Appeal).ToList();
        }

    }
}
