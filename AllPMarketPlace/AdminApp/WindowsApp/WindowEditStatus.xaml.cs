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
using AdminApp.ADOApp;
using AdminApp.ClassApp;

namespace AdminApp.WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для WindowEditStatus.xaml
    /// </summary>
    public partial class WindowEditStatus : Window
    {
        public static Appeal TheAppeal { get; set; }
        public WindowEditStatus(Appeal SelAppeal)
        {
            InitializeComponent();
            TheAppeal= SelAppeal;
            ListStatus.ItemsSource = App.Connection.TypeAppeal.ToList();
        }

        private void ListStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListStatus.SelectedItem != null)
            {
                if (MessageBox.Show("", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TheAppeal.TypeAppeal = ListStatus.SelectedItem as TypeAppeal;
                    App.Connection.SaveChanges();   
                    this.Close();
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
