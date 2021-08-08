using StoreApp.Models; 
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

namespace StoreApp.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            syncDB();
        }
        private void syncDB()
        {

            using var dbContext = new SqliteDBContext();
            var categories = dbContext.Categories.ToList<Category>();
            if (categories is not null)
            {
                catMCB.ItemsSource = categories.Select(c => c.CategoryName);
            }
        }

        private void goToCategories(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CategoriesPage());
        }

        private void goToProducts(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductsPage());
        }
        private void SyncDG(object sender, SelectionChangedEventArgs e)
        {
            using var dbContext = new SqliteDBContext();
            Category cat = dbContext.Categories.Where(c => c.CategoryName == catMCB.SelectedItem.ToString()).First();
            List<Product> pList = dbContext.Products.Where(p => p.CategoryId == cat.CategoryId).ToList<Product>();
            MainDG.ItemsSource = pList;
        }

        private void cCart_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CartPage());
        }

        private void cCheckout_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = new SqliteDBContext();
            var orders = dbContext.Orders.ToList<Order>();
            if (orders.Count == 0)
            {
                this.NavigationService.Navigate(new MainPage());
            }
            else
            {
                this.NavigationService.Navigate(new CheckoutPage());
            }
        }
    }
}
