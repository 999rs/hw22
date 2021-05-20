using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBasic
{
    /// <summary>
    /// класс корзины пользователя
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// ид юзера
        /// </summary>
        public int UserId;

        /// <summary>
        /// набор итемов
        /// </summary>
        public List<OrderItem> CartOrderItems = new List<OrderItem>();

        /// <summary>
        /// конструктор
        /// </summary>
        public Cart() { }
    }
    
}
