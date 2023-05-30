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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;
using SalesManApp.PagesApp;

namespace SalesManApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public static byte[] image { get; set; }
        public PageReg()
        {
            InitializeComponent();
            CMBProductMAker.ItemsSource = App.Connection.ProductMakers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(DateBirth.SelectedDate.ToString());
            image = ClassAllMethod.SelecktPhoto();
            if (image != null)
            {
                ImgAdmin.Source = ClassAllMethod.ByteToImage(image);
                (sender as Button).Background = Brushes.SkyBlue;
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
                        TxtPhone.Background = Brushes.LightGreen;

                    }
                    else
                    {
                        TxtPhone.Background = Brushes.White;

                    }

                }
                catch
                {
                    TxtPhone.Background = Brushes.Pink;
                }
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

                        TxtEmail.Background = Brushes.Pink;
                        if ((TxtEmail.Text).Split('@')[1].Split('.')[0].Length >= 2)
                        {

                            TxtEmail.Background = Brushes.Pink;
                            if ((TxtEmail.Text).Split('.')[1].Length >= 2)
                            {
                                TxtEmail.Background = Brushes.LightGreen;

                            }
                        }
                        else
                        {
                            TxtEmail.Background = Brushes.Pink;
                        }
                    }
                    else
                    {
                        TxtEmail.Background = Brushes.Pink;
                    }
                }
                else
                {
                    TxtEmail.Background = Brushes.White;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAtho());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "" && TxtLogin.Text != "" && TxtPassword.Text != "" &&
                TxtPhone.Text != "" && TxtEmail.Text != "" && image != null && DateBirth.SelectedDate != null)
            {
                if (TxtEmail.Background == Brushes.LightGreen && TxtPhone.Background == Brushes.LightGreen && CMBProductMAker.SelectedItem != null)
                {
                    Users NewUser = new Users()
                    {
                        FullName = TxtName.Text,
                        Phone = TxtPhone.Text,
                        Email = TxtEmail.Text,
                        Login = TxtLogin.Text,
                        Password = TxtPassword.Text,
                        PhotoUser = image,
                        BirthData = new DateTime(DateBirth.SelectedDate.Value.Year, DateBirth.SelectedDate.Value.Month, DateBirth.SelectedDate.Value.Day),
                        DateRegist = DateTime.Now,
                        Role_id = 2
                    };
                    App.Connection.Users.Add(NewUser);
                    var SelProdMAker = CMBProductMAker.SelectedItem as ProductMakers;
                    UsersPM NewPm = new UsersPM()
                    {
                        Users = NewUser,
                        ProductMakers = SelProdMAker,
                        IsBlock= true
                    };
                    App.Connection.UsersPM.Add(NewPm);
                    App.Connection.SaveChanges();
                    ClassAllMethod.MessageNormal("Регистрация прошла успешно \n ждите подтверждения аккаунта (3-5 минут)");
                    
                }
            }
            else
            {
                ClassAllMethod.MessageError("не все поля заполнены");
            }
        }
    }
}
