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
using AnalystApp.ClassApp;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Forms;

namespace AnalystApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageDaraRegistUser.xaml
    /// </summary>
    public partial class PageDaraRegistUser : Page
    {
        public  ChartElementType mainChartType = new ChartElementType();
        public System.Windows.Forms.DataVisualization.Charting.SeriesChartType ChartType { get; set; }
        public PageDaraRegistUser()
        {
            InitializeComponent();
            var Area = MainChart.ChartAreas.Add("MianArea");
            var legend = MainChart.Legends.Add("Main Legend");
            CMBTypeChart.ItemsSource = Enum.GetValues(typeof(SeriesChartType)).Cast<SeriesChartType>().ToList();
            Area.AxisX.Interval= 1;
            Area.AxisY.Interval= 1;
            MainChart.Series.Clear();

        }
        public void DefRes()
        {
            try
            {
                var SelectedChartType = (SeriesChartType)CMBTypeChart.SelectedItem;
                var startDate = DataStart.SelectedDate;
                var endDate = DataStop.SelectedDate.Value.Date;
                MainChart.Series.Clear();



                ///раб
                foreach (var Index in App.Connection.Users)
                {


                    var Seria = MainChart.Series.Add($"{Index.FullName} {Index.id_User}");
                    var ChartData = Index.Appeal.ToList().Where(z => z.DataCreate >= startDate.Value.Date && z.DataCreate <= endDate)
                            .OrderBy(z => z.DataCreate).GroupBy(z => z.DataCreate)
                            .ToDictionary(Keys => Keys.Key, value => value.Where(z => z.User_id == Index.id_User).Count());

                    
                    Seria.Points.DataBindXY(ChartData.Keys, ChartData.Values);
                    Seria.BorderWidth = 10;
                    Seria.ChartType = SelectedChartType;
                }
            }
            catch
            {
                ClassAllMethod.MessageError("Данная диаграмма не может быть построенна для таких данных(");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataStart.SelectedDate != null && DataStop.SelectedDate != null)
            {
                DefRes();
            }
            else
            {
                ClassAllMethod.MessageError("Выберетк 2 даты диапазона или воспользуйтесь специальной кнопкой");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
