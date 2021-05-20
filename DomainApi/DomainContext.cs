using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainBasic;
using Microsoft.EntityFrameworkCore;

 
namespace DomainApi
{
    public class DomainContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }


        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении


        }


        public void InsertValues()
        {
            this.Products.Add(new Product()
            {
                ProductId = 1,
                ProductBasicPrice = 100,
                ProductName = "Bread",
                ImagePath = "~/Img/Products/Bread.png",
                ProductDescription = "White Bread"
            });

            // соль
            this.Products.Add(new Product()
            {
                ProductId = 2,
                ProductBasicPrice = 20,
                ProductName = "Salt",
                ImagePath = "~/Img/Products/Salt.png",
                ProductDescription = "Pure chemical formula: NaCl"
            });


            this.OrderItems.Add(new OrderItem() { OrderItemId = 1, ProductId = 1, Quantity = 2 });
            this.OrderItems.Add(new OrderItem() { OrderItemId = 2, ProductId = 2, Quantity = 1 });
            this.OrderItems.Add(new OrderItem() { OrderItemId = 3, ProductId = 1, Quantity = 5 });
            this.OrderItems.Add(new OrderItem() { OrderItemId = 4, ProductId = 2, Quantity = 1 });

            this.Orders.Add(new Order() { OrderId = 1 });
            this.Orders.Add(new Order() { OrderId = 2 });

            this.Orders.Where(x => x.OrderId == 1).FirstOrDefault().OrderItems.Add(
                this.OrderItems.Where(i => i.OrderItemId == 1).FirstOrDefault());

            this.Orders.Where(x => x.OrderId == 1).FirstOrDefault().OrderItems.Add(
                this.OrderItems.Where(i => i.OrderItemId == 2).FirstOrDefault());

            this.Orders.Where(x => x.OrderId == 2).FirstOrDefault().OrderItems.Add(
                this.OrderItems.Where(i => i.OrderItemId == 3).FirstOrDefault());

            this.Orders.Where(x => x.OrderId == 2).FirstOrDefault().OrderItems.Add(
                this.OrderItems.Where(i => i.OrderItemId == 3).FirstOrDefault());

            this.SaveChanges();

        }


    }
}


