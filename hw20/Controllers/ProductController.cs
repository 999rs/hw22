using hw20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("About/{ProductId:int}")]
        public IActionResult About(int ProductId)
        {
            ProductModel model = new ProductModel(ProductId);
            return View(model);
            

        }
    }
}
