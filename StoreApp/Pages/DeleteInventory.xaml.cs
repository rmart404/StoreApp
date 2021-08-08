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
    /// Interaction logic for DeleteInventory.xaml
    /// </summary>
    public partial class DeleteInventory : Page
    {
        public DeleteInventory()
        {
            InitializeComponent();
            syncDB();
        }

        private void syncDB()
        {
            using var dbContext = new SqliteDBContext();
            var items = dbContext.Items.ToList<Item>();
            if (items is not null)
            {
                Combox.ItemsSource = items.Select(c => c.Name);
            }
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Combox.SelectedItem is not null)
            {
                string selected = Combox.SelectedItem.ToString();
                using var dbContext = new SqliteDBContext();
                Item item = dbContext.Items.Where<Item>(b => b.Name == selected).First();
                dbContext.Remove(item);
                dbContext.SaveChanges();
                this.NavigationService.Navigate(new DeleteInventory());
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
