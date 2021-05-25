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
        //private IHostingEnvironment _environment;
        //public ProductViewModel(IHostingEnvironment environment)
        //{
        //    _environment = environment;
        //}

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

        [BindProperty]
        public IFormFile Upload { get; set; }

        public ProductViewModel(Product product)
        {
            this.Product = product;
        }

    }
}
