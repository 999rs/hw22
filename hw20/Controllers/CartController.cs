using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DomainBasic;
using System.Security.Policy;
using hw20.Models;
using System.Text.Json;

namespace hw20.Controllers
{
    /// <summary>
    /// контроллер карзины
    /// </summary>
    public class CartController : Controller
    {
       
        /// <summary>
        /// просмотр карзины
        /// </summary>
        /// <returns></returns>
        public IActionResult CartView()
        {
            EnsureSessionParams();
          
            // вью модель
            CartViewModel model = new CartViewModel();
            ViewBag.Cart = HttpContext.Session.Get<Cart>("Cart");
            PopulateCartViewModel(model);

            // возврат вью
            return View(model);
        }

        /// <summary>
        /// проверка наличия объекта в параметрах сессии
        /// </summary>
        public void EnsureSessionParams()
        {
            if (!HttpContext.Session.Keys.Contains("Cart"))
            {
      
                Cart cart = new Cart();
                HttpContext.Session.Set<Cart>("Cart", cart);

            }
        }

        /// <summary>
        /// наполнение вью модели
        /// </summary>
        /// <param name="model"></param>
        public void PopulateCartViewModel(CartViewModel model)
        { 
            model.Cart = HttpContext.Session.Get<Cart>("Cart");
        }


    }
}
