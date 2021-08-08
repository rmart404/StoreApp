using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class SqliteDBContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\Ray\source\repos\StoreApp\StoreApp\db.sqlite");
            base.OnConfiguring(options);
        }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}
