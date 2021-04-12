using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBasic
{
    /// <summary>
    /// класс элемента заказа
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// ид элемента
        /// </summary>
        public int OrderItemId;

        /// <summary>
        /// ид продукта
        /// </summary>
        public int ProductId;

        /// <summary>
        /// кол-во едениц продукта
        /// </summary>
        public int Quantity;

        /// <summary>
        /// конструктор
        /// </summary>
        public OrderItem(){ }
    }
}
