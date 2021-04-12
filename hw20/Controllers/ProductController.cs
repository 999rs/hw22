using DomainBasic;
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

        [Route("ProductAbout/{ProductId:int}")]
        public IActionResult ProductAbout(int ProductId)
        {
            ProductViewModel model = new ProductViewModel(ProductId);
            return View(model);
            

        }


        [Route("AddToCart/{ProductId:int}/{Quantity:int}")]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            //Cart userCart = new Cart();
            //if (ViewBag.Cart != null)
            //    userCart = ViewBag.Cart as Cart;

            Cart cart = HttpContext.Session.Get<Cart>("Cart");


            cart.CartOrderItems.Add(new OrderItem() { ProductId = ProductId, Quantity = Quantity });

            HttpContext.Session.Set<Cart>("Cart", cart);

            return new JsonResult(new {result = "ok", posCount = cart.CartOrderItems.Count, itemCount = cart.CartOrderItems.Sum(x => x.Quantity) });
        }
    }
}
