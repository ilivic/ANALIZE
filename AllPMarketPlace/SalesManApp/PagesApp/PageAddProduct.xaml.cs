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
using SalesManApp.ADOApp;
using SalesManApp.ClassApp;

namespace SalesManApp.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        public static List<Category> ListCat { get; set; }
        public static byte[] image { get; set; }
        public static Category SelCat { get; set; }
        public static List<Category> ListCatStatic { get; set; }
        public static int index = 0;
        public static int indexMax = 0;

        public PageAddProduct()
        {
            InitializeComponent();
            InsertPublick();
            LIstInsert();
        }
        public void InsertPublick()
        {
            ListCat = new List<Category>(App.Connection.Category.ToList());
            ListCatStatic = new List<Category>(ListCat.ToList());
        }
        public void InsertSerch()
        {
            ListCat = new List<Category>(App.Connection.Category.Where(z=>z.Title.Contains(TxtSerch.Text)).ToList());
            ListCatStatic = new List<Category>(ListCat.ToList());
        }
        private void TxtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtSerch.Text != "")
            {
                InsertSerch();
                LIstInsert();
            }
            else
            {
                InsertPublick();
                LIstInsert();
            }
        }
        public void LIstInsert()
        {
            indexMax = ListCat.ToList().Count();
           Steps();
        }
        public void Steps()
        {
            try
            {
                ListCat = ListCatStatic;
                SelCAtegorus.ItemsSource = ListCat.Skip(index).Take(1).ToList();
                SelCat = ListCat.Skip(index).Take(1).First();
            }
            catch
            {
                
            }
        }

        private void ClIndeBack(object sender, RoutedEventArgs e)
        {
                index--;
            if (index == -1)
            {
                index = indexMax -1;
                Steps();
            }
            else
            {
                Steps();
            }
        }

        private void CLIndexGo(object sender, RoutedEventArgs e)
        {
            if (index == indexMax -1)
            {
                index = 0;
                Steps();
            }
            else
            {
                index++;
                Steps();
            }
        }

        private void ClEventSelectPhoto(object sender, RoutedEventArgs e)
        {
            image = ClassAllMethod.SelecktPhoto();
            if (image != null)
            {
                IMGProd.Source = ClassAllMethod.ByteToImage(image);
                (sender as Button).Background = Brushes.Green;
            }
        }

        private void ClEventAddProduct(object sender, RoutedEventArgs e)
        {

            if (TxtPrice.Text != "" && TxtTitle.Text != "" && image != null && SelCat != null)
            {
                try
                {

                    Products newProd = new Products()
                    {
                        Photo = image,
                        Title = TxtTitle.Text,
                        Price = (decimal)(double.Parse(TxtPrice.Text)),
                        Category_id = SelCat.id_category,
                        IsBlock = false,
                        ProductMaket_id = ClassAllMethod.CorrPM.id_ProductMakers
                    };
                    App.Connection.Products.Add(newProd);
                    App.Connection.SaveChanges();
                    ClassAllMethod.MessageNormal("Продук успешно добавлен под вашим брендом");
                }
                catch
                {
                ClassAllMethod.MessageError("поля заполнены не корректно");
                    
                }
            }
            else
            {
                ClassAllMethod.MessageError("не все поля заполнены");
            }
        }
    }
}
