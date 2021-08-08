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
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void TSH_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item Added to Cart");
            int quantity = 1;
            using var dbContext = new SqliteDBContext();
            string name = "Travis Scott High";
            Item item = dbContext.Items.Where(b => b.Name == name).First();

            double taxes = item.Price * quantity * (8.25 / 100);

            var orders = dbContext.Orders.ToList<Order>();
            List<string> names = new List<string>();

            foreach (var Names in orders)
            {
                string NAMES = Names.Product_Name;
                names.Add(NAMES);
            }

            if (names.Contains(name))
            {
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == name).First();
                double Taxes = item.Price * order.Quantity * (8.25 / 100);
                order.Quantity += 1;
                order.Subtotal = item.Price * order.Quantity + Taxes;
                Math.Round(Convert.ToDecimal(order), 2);
                dbContext.SaveChanges();
            }
            else
            {
                dbContext.Add(new Order { Product_Name = item.Name, Quantity = quantity, Subtotal = item.Price * quantity + taxes });
                dbContext.SaveChanges();
            }
        }



        private void redOctober_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item Added to Cart");
            int quantity = 1;
            using var dbContext = new SqliteDBContext();
            string name = "Yeezy Red October";
            Item item = dbContext.Items.Where<Item>(b => b.Name == name).First();

            double taxes = item.Price * quantity * (8.25 / 100);

            var orders = dbContext.Orders.ToList<Order>();
            List<string> names = new List<string>();

            foreach (var Names in orders)
            {
                string NAMES = Names.Product_Name;
                names.Add(NAMES);
            }

            if (names.Contains(name))
            {
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == name).First();
                double Taxes = item.Price * order.Quantity * (8.25 / 100);
                order.Quantity += 1;
                order.Subtotal = item.Price * order.Quantity + Taxes;
                Math.Round(Convert.ToDecimal(order), 2);
                dbContext.SaveChanges();
            }
            else
            {
                dbContext.Add(new Order { Product_Name = item.Name, Quantity = quantity, Subtotal = item.Price * quantity + taxes });
                dbContext.SaveChanges();
            }
        }

        private void solar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item Added to Cart");
            int quantity = 1;
            using var dbContext = new SqliteDBContext();
            string name = "Yeezy Solar";
            Item item = dbContext.Items.Where<Item>(b => b.Name == name).First();

            double taxes = item.Price * quantity * (8.25 / 100);

            var orders = dbContext.Orders.ToList<Order>();
            List<string> names = new List<string>();

            foreach (var Names in orders)
            {
                string NAMES = Names.Product_Name;
                names.Add(NAMES);
            }

            if (names.Contains(name))
            {
                Order order = dbContext.Orders.Where<Order>(b => b.Product_Name == name).First();
                double Taxes = item.Price * order.Quantity * (8.25 / 100);
                order.Quantity += 1;
                order.Subtotal = item.Price * order.Quantity + Taxes;
                Math.Round(Convert.ToDecimal(order), 2);
                dbContext.SaveChanges();
            }
            else
            {
                dbContext.Add(new Order { Product_Name = item.Name, Quantity = quantity, Subtotal = item.Price * quantity + taxes });
                dbContext.SaveChanges();
            }
        }

        }
    }
