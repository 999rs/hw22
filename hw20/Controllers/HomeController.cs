using hw20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Controllers
{

    /// <summary>
    /// доманший контроллер
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// главное окно сайта
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //var x = DataApiCalls.Products.GetProductById(2);

            //x.ProductName = x.ProductName + "_apiUpdate";

            //var u = DataApiCalls.Products.Update(x);
            

            //var t = "test";

            //var z = DataApiCalls.Products.Create(new DomainBasic.Product()
            //{
            //    ImageData = x.ImageData,
            //    ProductBasicPrice = x.ProductBasicPrice,
            //    ProductName = x.ProductName+ "_api",
            //    ProductDescription = x.ProductDescription,
            //}); 
            

            return View();
        }

        /// <summary>
        /// показать даннные прайваси
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// показ ошибки
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
