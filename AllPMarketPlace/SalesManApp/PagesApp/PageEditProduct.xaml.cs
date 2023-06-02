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
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;

namespace SalesManApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageEditProduct.xaml
    /// </summary>
    public partial class PageEditProduct : Page
    {
        public static Products SelProduct { get; set; }
        public PageEditProduct(Products SelProd)
        {
            InitializeComponent();
            SelProduct= SelProd;
            Refresh();
        }
        public void Refresh()
        {
            DataContext = SelProduct;
            LIstGall.ItemsSource = App.Connection.ProductGalls.Where(z => z.Product_id == SelProduct.Id_prod).ToList();
            TxtNameCat.Text = SelProduct.Category.Title;
            imgCat.Source = ClassAllMethod.ByteToImage(SelProduct.Category.Photo);
            MianPhotoIMG.Source = ClassAllMethod.ByteToImage(SelProduct.Photo);
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {

            App.Connection.SaveChanges();
            ClassAllMethod.MessageNormal("изменения сохранены");
            }
            catch (Exception ex) 
            {
                ClassAllMethod.MessageError(ex.Message);
            }
        }

        private void LIstGall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LIstGall.SelectedItem != null)
            {
                var img = LIstGall.SelectedItem as ProductGalls;
                MianPhotoIMG.Source = ClassAllMethod.ByteToImage(img.Photo);
            }
        }
    }
}
