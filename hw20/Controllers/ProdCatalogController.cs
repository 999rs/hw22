using DomainBasic;
using hw20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Controllers
{
    /// <summary>
    /// контроллер каталога
    /// </summary>
    public class ProdCatalogController : Controller
    {
        
        /// <summary>
        /// просмотр каталога
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdCatView()
        {
            //ViewBag.Cart = HttpContext.Session.Get<Cart>("Cart");


            ProdCatalogViewModel model = new ProdCatalogViewModel();

            // передадим корзину из сессии в модель для отображения количества (в каталоге)
            model.Cart = HttpContext.Session.Get<Cart>("Cart");

            return View(model);
        }



    }
}
