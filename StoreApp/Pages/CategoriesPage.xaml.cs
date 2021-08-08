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
using StoreApp.Models;

namespace StoreApp.Pages
{
    /// <summary>
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            _ = this.NavigationService.Navigate(new MainPage());
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductsPage());
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            if (NewCategoryName.Text != "")
            {
                
                using var dbContext = new SqliteDBContext();
                dbContext.Categories.Add(new() { CategoryName = NewCategoryName.Text });
                dbContext.SaveChanges();
                NewCategoryName.Text = "";
                _ = this.NavigationService.Navigate(new MainPage());
            }
        }


    }
}
