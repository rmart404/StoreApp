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
    /// Interaction logic for CheckoutPage.xaml
    /// </summary>
    public partial class CheckoutPage : Page
    {
        public CheckoutPage()
        {
            InitializeComponent();
            syncDb();
            Date();
            syncdatabase();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = new SqliteDBContext();
            foreach (var row in dbContext.Orders)
            {
                dbContext.Remove(row);
                dbContext.SaveChanges();
            }
            this.NavigationService.Navigate(new LoginPage());
        }

        private void syncDb()
        {
            double total = 0.0;
            using var dbContext = new SqliteDBContext();
            var Listorders = dbContext.Orders.ToList<Order>();

            foreach (var num in dbContext.Orders)
            {
                total += num.Subtotal;
            }

            Double Total = Math.Round((Double)total, 2);

            label.Content = Total;
        }

        private void Date()
        {
            date.Content = DateTime.Now.ToString();
        }

        private void syncdatabase()
        {
            using var dbContext = new SqliteDBContext();
            var ListOrders = dbContext.Orders.ToList<Order>();
            if (ListOrders is not null)
            {
                List.ItemsSource = ListOrders;
            }
        }
    }
}
