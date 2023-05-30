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
using static System.Net.Mime.MediaTypeNames;
using AdminApp.ADOApp;
using AdminApp.ClassApp;

namespace AdminApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageAddCat.xaml
    /// </summary>
    public partial class PageAddCat : Page
    {
        public static byte[] image { get; set; }
        public PageAddCat()
        {
            InitializeComponent();
        }

        private void CLEventSelectPhoto(object sender, RoutedEventArgs e)
        {
            image = ClassAllMethod.SelecktPhoto();
            if (image != null)
            {
                ImgAdmin.Source = ClassAllMethod.ByteToImage(image);
                (sender as Button).Background = Brushes.SkyBlue;
            }
        }

        private void ClEnetAddCat(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "" && image != null)
            {
                Category NewCat = new Category
                {
                    Title = TxtName.Text,
                    Photo = image,
                };
                App.Connection.Category.Add(NewCat);
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal("Добавление Успешно");
            }
            else 
            {
                ClassAllMethod.MessageError("Не все поля заполнены");

            }
        }
    }
}
