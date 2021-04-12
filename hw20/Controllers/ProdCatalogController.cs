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
            ProdCatalogViewModel model = new ProdCatalogViewModel();
            return View(model);
        }



    }
}
