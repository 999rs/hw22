using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Controllers
{

    /// <summary>
    /// контроллер заказа
    /// </summary>
    public class OrderController : Controller
    {
        /// <summary>
        /// информация о заказе
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
