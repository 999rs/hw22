using DomainBasic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    /// <summary>
    /// вьюмодель продукта
    /// </summary>
    public class ProductViewModel : PageModel
    {
        /// <summary>
        /// конструктор
        /// </summary>
        public ProductViewModel()
        { 
            Product= new Product();
        }

        /// <summary>
        /// продукт
        /// </summary>
        [BindProperty]
        public Product Product { get; set; }
        public string modelInfo = "empty";

        /// <summary>
        /// приложенный файл
        /// </summary>
        [BindProperty]
        public IFormFile Upload { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="product"></param>
        public ProductViewModel(Product product)
        {
            this.Product = product;
        }

    }
}
