using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBasic
{
    /// <summary>
    /// класс заказа
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ид заказа
        /// </summary>
        public int OrderId;

        /// <summary>
        /// наполнение заказа
        /// </summary>
        public List<OrderItem> OrderItems = new List<OrderItem>();

    }
}
