using System;

namespace DomainBasic
{
    /// <summary>
    /// класс продукта
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ид продукта
        /// </summary>
        public int ProductId;

        /// <summary>
        /// имя продукта 
        /// </summary>
        public string ProductName;

        /// <summary>
        /// описание продукта
        /// </summary>
        public string ProductDescription;

        /// <summary>
        /// базовая цена продукта
        /// </summary>
        public double ProductBasicPrice;


        /// <summary>
        /// путь к картинке продукта
        /// </summary>
        public string ImagePath;
    }
}
