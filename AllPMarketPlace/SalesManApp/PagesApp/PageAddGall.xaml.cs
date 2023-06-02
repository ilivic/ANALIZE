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
    /// Логика взаимодействия для PageAddGall.xaml
    /// </summary>
    public partial class PageAddGall : Page
    {
        
        public static List<Products> ListProduct { get; set; }
        public static List<Products> ListProductStatic { get; set; }
        public static List<Des> listFalse { get; set; }
        public PageAddGall()
        {
            InitializeComponent();
            ListProductStatic = new List<Products>(App.Connection.Products.Where(z => z.ProductMaket_id == ClassAllMethod.CorrPM.id_ProductMakers).ToList());
            DefoltInput();
            InserCMB();
        }
        public partial class Des
        {
            public bool Chec { get; set; }
            public string Title { get; set; }

        }
        public void InserCMB()
        {
            var listCat = new List<Category>(App.Connection.Category.ToList());
            listCat.Add(new Category() { Title = "Всё" });
            CMBCate.ItemsSource= listCat;
            listFalse = new List<Des>();
            listFalse.Add(new Des() { Chec = true, Title= "заблокирован" });
            listFalse.Add(new Des() { Chec = false, Title = "Не заблокирован" });
            listFalse.Add(new Des() { Chec = true, Title = "Всё" });
            CMBIsBlock.ItemsSource = listFalse.ToList();

        }
        public void DefoltInput()
        {
            ListProduct = new List<Products>(ListProductStatic.ToList());
            DefoltRefresh();
        }
        public void DefoltRefresh() 
        {
            ListProd.ItemsSource = ListProduct;
        }

        private void ListProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtSerch.Text != "")
            {
                ListProduct = ListProduct.Where(z => z.Title.Contains(TxtSerch.Text)).ToList();
                DefoltRefresh();
            }
            else
            {
                DefoltInput();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListProduct = ListProduct.OrderBy(z=>z.Price).ToList();
                DefoltRefresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListProduct = ListProduct.OrderByDescending(z=>z.Price).ToList();
                DefoltRefresh();

        }
        private void CMBCate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListProd.Items.Count != 0 && CMBCate.SelectedItem != null)
            {
                    var SelectCat = (CMBCate.SelectedItem as Category);
                if (SelectCat.Title != "Всё")
                {
                    ListProduct = ListProduct.Where(z => z.Category_id == SelectCat.id_category).ToList();
                    DefoltRefresh();
                }
                else
                {
                    DefoltInput();
                }
            }
            else
            {
                DefoltInput();
            }
        }

        private void CMBIsBlock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListProd.Items.Count != 0 && CMBIsBlock.SelectedItem != null)
            {
                var SelectBlock = CMBIsBlock.SelectedItem as Des;
                if (SelectBlock.Title != "Всё")
                {
                    ListProduct = ListProduct.Where(z => z.IsBlock == SelectBlock.Chec).ToList();
                    DefoltRefresh();

                }
                else
                {
                    DefoltInput();
                };
            }
            else
            {
                DefoltInput();
            }
        }

        private void ClEventEditStatus(object sender, RoutedEventArgs e)
        {
            var ContexKey= (sender as MenuItem).DataContext as Products;
            ContexKey.IsBlock = !ContexKey.IsBlock;
            App.Connection.SaveChanges();
            DefoltInput();
            
        }

        private void ClEventShowProd(object sender, RoutedEventArgs e)
        {
            var ContexKey = (sender as MenuItem).DataContext as Products;
            NavigationService.Navigate(new PageEditProduct(ContexKey));
          
        }

        private void ClEventAddGall(object sender, RoutedEventArgs e)
        {
            var ContexKey = (sender as MenuItem).DataContext as Products;
            NavigationService.Navigate(new PageAddProductGall(ContexKey));
        }
    }
}
