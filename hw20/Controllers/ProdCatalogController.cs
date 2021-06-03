using DomainBasic;
using hw20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFRepository;

namespace hw20.Controllers
{
    /// <summary>
    /// контроллер каталога
    /// </summary>
    public class ProdCatalogController : Controller
    {
        //IRepository db;

        //public ProdCatalogController()
        //{
        //    db = new SQLRepository();
        //}

        /// <summary>
        /// просмотр каталога
        /// </summary>
        /// <returns></returns>
        public ActionResult ProdCatView()
        {

            //ProdCatalogViewModel model = new ProdCatalogViewModel(db.GetAllProductList());
            ProdCatalogViewModel model = new ProdCatalogViewModel(DataApiCalls.Products.GetAllProducts());

            // передадим корзину из сессии в модель для отображения количества (в каталоге)
            model.Cart = HttpContext.Session.Get<Cart>("Cart");

            return View(model);
        }



    }
}
