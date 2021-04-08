using hw20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Controllers
{
    public class ProdCatalogController : Controller
    {
        // GET: ProdCatalogController
        public ActionResult Index()
        {
            ProdCatalogViewModel model = new ProdCatalogViewModel();
            return View(model);
        }



    }
}
