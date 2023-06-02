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
using Microsoft.Win32;
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;
using System.IO;

namespace SalesManApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageAddProductGall.xaml
    /// </summary>
    public partial class Gallers
    {
        public byte[] Photos { get; set; }
    }
    public partial class PageAddProductGall : Page
    {
        public static Products SelProduct { get; set; }
        public static List<Gallers> TaketList { get; set; }
        public PageAddProductGall(Products SelProd)
        {
            InitializeComponent();
            SelProduct = SelProd;
            TaketList = new List<Gallers>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                if (dialog.ShowDialog() != null)
                {
                    TaketList.Clear();
                    foreach (var Selecter in dialog.FileNames)
                    {
                        TaketList.Add(new Gallers() { Photos=File.ReadAllBytes(Selecter)});
                    };
                    ListGall.ItemsSource = null;
                    ListGall.ItemsSource= TaketList;
                    (sender as Button).Background = Brushes.Green;
                }
            }
            catch
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TaketList.Count !=0)
            {
                foreach (var Selecter in TaketList)
                {
                    ProductGalls NewGals = new ProductGalls()
                    {
                        Photo = Selecter.Photos,
                        Product_id = SelProduct.Id_prod
                    };
                    App.Connection.ProductGalls.Add(NewGals);
                }
                App.Connection.SaveChanges();
                ClassAllMethod.MessageNormal("Галерея товара пополнена");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var SelectKey = (sender as MenuItem).DataContext as Gallers;
            TaketList.Remove(SelectKey);
            if (TaketList.Count == 0)
            {
                BtnSelect.Background = Brushes.Pink;
            }
            ListGall.ItemsSource = null;
            ListGall.ItemsSource = TaketList;
        }
    }
}
