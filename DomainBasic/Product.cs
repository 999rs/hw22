using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.IO;

namespace DomainBasic
{
    /// <summary>
    /// класс продукта
    /// </summary>
    public class Product
    {
        ///// <summary>
        ///// приватное поле с именем файла
        ///// </summary>        
        //private Guid _FileNameGuid = Guid.NewGuid();

        public Product()
        {
            this.ImageData = new byte[0];
        }


        /// <summary>
        /// ид продукта
        /// </summary>
        public int Id {get;set;}
        //public int key;

        /// <summary>
        /// имя продукта 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// описание продукта
        /// </summary>
        [Required]
        public string ProductDescription { get; set; }

        /// <summary>
        /// базовая цена продукта
        /// </summary>
        [Required]
        public double ProductBasicPrice { get; set; }



        /// <summary>
        /// храним картинку в бд
        /// </summary>
        [Required]
        public byte[] ImageData { get; set; }

        /// <summary>
        /// сохраняет картинку в файл
        /// </summary>
        /// <param name="fileName"></param>
        public void DownloadImage(string fileName)
        {
            File.WriteAllBytesAsync(fileName, this.ImageData);
        }
    }
}
