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
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            syncDB();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductsPage());
        }


        private void syncDB()
        {
            using var dbContext = new SqliteDBContext();
            var Listitems = dbContext.Orders.ToList<Order>();
            if (Listitems is not null)
            {
                ListItems.ItemsSource = Listitems;
                cartSelect.ItemsSource = Listitems.Select(c => c.Product_Name);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (cartSelect.SelectedItem is not null)
            {
                using var dbContext = new SqliteDBContext();
                string selected = cartSelect.SelectedItem.ToString();
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == selected).First();
                Item item = dbContext.Items.Where<Item>(b => b.Name == selected).First();
                double Taxes = item.Price * order.Quantity * (8.25 / 100);
                order.Quantity += 1;
                order.Subtotal = item.Price * order.Quantity + Taxes;
                dbContext.SaveChanges();
                this.NavigationService.Navigate(new CartPage());
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            if (cartSelect.SelectedItem is not null)
            {
                using var dbContext = new SqliteDBContext();
                string selected = cartSelect.SelectedItem.ToString();
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == selected).First();
                Item item = dbContext.Items.Where<Item>(b => b.Name == selected).First();
                double Taxes = item.Price * order.Quantity * (8.25 / 100);
                order.Quantity -= 1;
                dbContext.SaveChanges();

                if (order.Quantity == 0)
                {
                    dbContext.Remove(order);
                    dbContext.SaveChanges();
                    this.NavigationService.Navigate(new CartPage());
                }
                else
                {
                    order.Subtotal = item.Price * order.Quantity + Taxes;
                    dbContext.SaveChanges();
                    this.NavigationService.Navigate(new CartPage());
                }
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (cartSelect.SelectedItem is not null)
            {
                string selected = cartSelect.SelectedItem.ToString();
                using var dbContext = new SqliteDBContext();
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == selected).First();
                dbContext.Remove(order);
                dbContext.SaveChanges();
                this.NavigationService.Navigate(new CartPage());
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

    }
}
