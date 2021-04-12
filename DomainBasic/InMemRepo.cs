using System.Collections.Generic;
using System.Linq;

namespace DomainBasic
{
    /// <summary>
    /// класс репозитория 
    /// </summary>
    public static class InMemRepo
    {
        public static List<Product> ProductsRepo = new List<Product>();
        public static List<Order> OrdersRepo = new List<Order>();
        public static List<OrderItem> OrderItemRepo = new List<OrderItem>();


        /// <summary>
        ///  конструктор и начальные данные
        /// </summary>
        static InMemRepo()
        {

            // хлеб
            ProductsRepo.Add(new Product()
            {
                ProductId = 1,
                ProductBasicPrice = 100,
                ProductName = "Bread",
                ImagePath = "~/Img/Products/Bread.png",
                ProductDescription = "White Bread"
            });

            // соль
            ProductsRepo.Add(new Product()
            {
                ProductId = 2,
                ProductBasicPrice = 20,
                ProductName = "Salt",
                ImagePath = "~/Img/Products/Salt.png",
                ProductDescription = "Pure chemical formula: NaCl"
            });

            // заказы
            OrderItemRepo.Add(new OrderItem() { OrderItemId = 1, ProductId = 1, Quantity = 2 });
            OrderItemRepo.Add(new OrderItem() { OrderItemId = 2, ProductId = 2, Quantity = 1 });
            OrderItemRepo.Add(new OrderItem() { OrderItemId = 3, ProductId = 1, Quantity = 5 });
            OrderItemRepo.Add(new OrderItem() { OrderItemId = 4, ProductId = 2, Quantity = 1 });

            OrdersRepo.Add(new Order() { OrderId = 1 });
            OrdersRepo.Add(new Order() { OrderId = 2 });

            OrdersRepo.Where(x => x.OrderId == 1).FirstOrDefault().OrderItems.Add(
                OrderItemRepo.Where(i => i.OrderItemId == 1).FirstOrDefault());

            OrdersRepo.Where(x => x.OrderId == 1).FirstOrDefault().OrderItems.Add(            
                OrderItemRepo.Where(i => i.OrderItemId == 2).FirstOrDefault());

            OrdersRepo.Where(x => x.OrderId == 2).FirstOrDefault().OrderItems.Add(
                OrderItemRepo.Where(i => i.OrderItemId == 3).FirstOrDefault());

            OrdersRepo.Where(x => x.OrderId == 2).FirstOrDefault().OrderItems.Add(
                OrderItemRepo.Where(i => i.OrderItemId == 3).FirstOrDefault());
        }
    }
}