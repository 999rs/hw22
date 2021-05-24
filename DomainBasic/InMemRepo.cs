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
                Id = 1,
                ProductBasicPrice = 100,
                ProductName = "Хлеб",
                ImagePath = "~/Img/Products/Bread.jpg",
                ProductDescription = "Белый хлеб собственной выпечки. Изготовлен из лучших продуктов в лучших традициях пекарного дела."
            });

            // соль
            ProductsRepo.Add(new Product()
            {
                Id = 2,
                ProductBasicPrice = 20,
                ProductName = "Соль",
                ImagePath = "~/Img/Products/Salt.jpg",
                ProductDescription = "Природная соль без искуственных добавок."
            });

            ProductsRepo.Add(new Product()
            {
                Id = 3,
                ProductBasicPrice = 100,
                ProductName = "Юникорн Спешиал",
                ImagePath = "~/Img/Products/virezkaFront.jpg",
                ProductDescription = "Фирменная вырезка Юникорн Спешиал. Ароматное мясо к вашему столу!"
            });

            ProductsRepo.Add(new Product()
            {
                Id = 4,
                ProductBasicPrice = 100,
                ProductName = "Левая голень",
                ImagePath = "~/Img/Products/virezkaLeft.jpg",
                ProductDescription = "Вырезка левой голени. Превосходный вкус! Ноль калорий!"
            });
            ProductsRepo.Add(new Product()
            {
                Id = 5,
                ProductBasicPrice = 100,
                ProductName = "Правая голень",
                ImagePath = "~/Img/Products/virezkaMiddle.jpg",
                ProductDescription = "Вырезка правой голени. Богата клетчаткой!"
            });


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