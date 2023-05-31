using AnalystApp.ClassApp;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace AnalystApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageLivesUsers.xaml
    /// </summary>
    public partial class PageLivesUsers : Page
    {
        public SeriesCollection seriesCollection { get; set; }
        public PageLivesUsers()
        {
            InitializeComponent();
            Main();
        }
        public void Main()
        {
            double summ = App.Connection.Users.ToList().Count();
            double ValOn = (App.Connection.Users.Where(z=>z.Role_id ==1).ToList().Count())/summ;
            double ValSe = (App.Connection.Users.Where(z=>z.Role_id ==2).ToList().Count())/summ;
            double ValTh = (App.Connection.Users.Where(z=>z.Role_id ==3).ToList().Count())/summ;
            double ValFr = (App.Connection.Users.Where(z=>z.Role_id ==4).ToList().Count())/summ;
            double ValFi = (App.Connection.Users.Where(z=>z.Role_id ==5).ToList().Count())/summ;
            seriesCollection = new SeriesCollection()
            {
                new PieSeries
                {
                    Title= "Покупатель",
                    Values = new ChartValues<ObservableValue> { new ObservableValue (ValOn) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title= "Продавец",
                    Values = new ChartValues<ObservableValue> { new ObservableValue (ValSe) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title= "Менеджер",
                    Values = new ChartValues<ObservableValue> { new ObservableValue (ValTh) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title= "Администратор",
                    Values = new ChartValues<ObservableValue> { new ObservableValue (ValFr) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title= "Аналитик",
                    Values = new ChartValues<ObservableValue> { new ObservableValue (ValFi) },
                    DataLabels = true,
                },
            };
            DataContext = this;
        }
    }
}
