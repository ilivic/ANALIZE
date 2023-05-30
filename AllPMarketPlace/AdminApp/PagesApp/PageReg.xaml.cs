using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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


namespace AdminApp.PagesApp
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAutho());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TxtName.Text != "" && TxtLogin.Text != "" && TxtPassword.Text != "" &&
                TxtPhone.Text != "" && TxtEmail.Text != "" && image != null && DateBirth.SelectedDate != null)
            {
                if (TxtEmail.Background == Brushes.SkyBlue && TxtPhone.Background == Brushes.SkyBlue)
                {
                    Users NewUser = new Users()
                    {
                        FullName = TxtName.Text,
                        Phone= TxtPhone.Text,
                        Email = TxtEmail.Text,
                        Login = TxtLogin.Text,
                        Password= TxtPassword.Text,
                        PhotoUser = image,
                        BirthData = new DateTime(DateBirth.SelectedDate.Value.Year, DateBirth.SelectedDate.Value.Month, DateBirth.SelectedDate.Value.Day),
                        DateRegist = DateTime.Now,
                        Role_id = 4
                    };
                    App.Connection.Users.Add(NewUser);
                    App.Connection.SaveChanges();
                    ClassAllMethod.MessageNormal("Регистрация прошла успешно");
                }
            }
            else 
            {
                ClassAllMethod.MessageError("не все поля заполнены");
            }
        }
    }
}
