using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

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
        [Key]
        public int ProductId;
        //public int key;

        /// <summary>
        /// имя продукта 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// описание продукта
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// базовая цена продукта
        /// </summary>
        public double ProductBasicPrice { get; set; }


        /// <summary>
        /// путь к картинке продукта
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// храним картинку в бд
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}
