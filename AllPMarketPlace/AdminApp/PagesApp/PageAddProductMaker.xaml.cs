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
    /// Логика взаимодействия для PageAddProductMaker.xaml
    /// </summary>
    public partial class PageAddProductMaker : Page
    {
        public static byte[] image { get; set; }
        public PageAddProductMaker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            image = ClassAllMethod.SelecktPhoto();
            if (image != null)
            {
                ImaProductMaker.Source = ClassAllMethod.ByteToImage(image);
                (sender as Button).Background = Brushes.SkyBlue;
            }
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtEmail.Text != "")
            {
                var KeyOne = "@";
                var KeyTwo = ".";
                if ((TxtEmail.Text).Contains(KeyOne) && (TxtEmail.Text).Contains(KeyTwo))
                {
                    if ((TxtEmail.Text).Split('@')[0].Length >= 5)
                    {

                        TxtEmail.Background = Brushes.Orange;
                        if ((TxtEmail.Text).Split('@')[1].Split('.')[0].Length >= 2)
                        {

                            TxtEmail.Background = Brushes.Orange;
                            if ((TxtEmail.Text).Split('.')[1].Length >= 2)
                            {
                                TxtEmail.Background = Brushes.SkyBlue;

                            }
                        }
                        else
                        {
                            TxtEmail.Background = Brushes.Orange;
                        }
                    }
                    else
                    {
                        TxtEmail.Background = Brushes.Orange;
                    }
                }
                else
                {
                    TxtEmail.Background = Brushes.White;
                }
            }
        }

        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtPhone.Text != "")
            {

                var SelText = TxtPhone.Text.Split('+')[1];
                try
                {
                    long.Parse(SelText);

                    TxtPhone.Background = Brushes.White;
                    if (TxtPhone.Text.Split('+')[1].Length >= 11)
                    {
                        TxtPhone.Background = Brushes.SkyBlue;

                    }
                    else
                    {
                        TxtPhone.Background = Brushes.White;

                    }

                }
                catch
                {
                    TxtPhone.Background = Brushes.Orange;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TxtEmail.Background == Brushes.SkyBlue && TxtPhone.Background == Brushes.SkyBlue && TxtName.Text != null &&
                (TxtTMe.Text).Contains("@") && TxtInfo.Text != "" && image != null)
            {
                ProductMakers NewMaker = new ProductMakers()
                {
                    Name = TxtName.Text,
                    Info = TxtInfo.Text,
                    Phone = TxtPhone.Text,
                    Email = TxtEmail.Text,
                    TMe = TxtTMe.Text,
                    Photo = image
                };
                App.Connection.ProductMakers.Add(NewMaker);
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal("Добавление новго бренда прошло успешно");
            }
            else
            {
                ClassAllMethod.MessageError("не все поля заполнены");
            }
        }
    }
}
