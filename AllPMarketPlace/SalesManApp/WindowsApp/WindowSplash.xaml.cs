using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;


namespace SalesManApp.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для WindowSplash.xaml
    /// </summary>
    public partial class WindowSplash : Window
    {
        public static List<SplashText> SelectionSplah { get; set; }
        Random random = new Random();
        public int Index = -1;
        DispatcherTimer timer = new DispatcherTimer();
        public WindowSplash()
        {
            InitializeComponent();
            SelectionSplah = new List<SplashText>(ClassAllMethod.ListSplashGet());
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(5000);
            timer.Start();
            DataSelect();
        }

        public void DataSelect()
        {

        }
        #region Splash
        public void Defolt()
        {
            DataContext = SelectionSplah[random.Next(0, SelectionSplah.Count - 1)];
        }
        public void refresh()
        {
            ProgBarTick.Value = Index;
            TxtProgress.Text = Index.ToString() + " %";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Index++;
            refresh();
            switch (Index)
            {
                case 0:
                    {
                        Defolt();
                        break;
                    }
                case 10:
                    {
                        Defolt();
                        break;
                    }
                case 20:
                    {
                        Defolt();
                        break;
                    }
                case 30:
                    {
                        Defolt();
                        break;
                    }
                case 40:
                    {
                        Defolt();
                        break;
                    }
                case 50:
                    {
                        Defolt();
                        break;
                    }
                case 60:
                    {
                        Defolt();
                        break;
                    }
                case 70:
                    {
                        Defolt();
                        break;
                    }
                case 80:
                    {
                        Defolt();
                        break;
                    }
                case 90:
                    {
                        Defolt();
                        break;
                    }
                case 100:
                    {
                        Defolt();
                        timer.Stop();
                        this.Close();
                        break;
                    }
            }
        }
        #endregion
    }
}
