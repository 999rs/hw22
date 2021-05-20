using DomainBasic;
using hw20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace hw20.Controllers
{
    /// <summary>
    /// контроллер продукта
    /// </summary>
    [Route("Product")]
    public class ProductController : Controller
    {

        /// <summary>
        /// информация о продукте
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [Route("ProductAbout/{ProductId:int}")]
        public IActionResult ProductAbout(int ProductId)
        {
            ProductViewModel model = new ProductViewModel(ProductId);
            return View(model);
            

        }


        /// <summary>
        /// добавление продукта в карзину
        /// </summary>
        /// <param name="ProductId">ид продукта</param>
        /// <param name="Quantity">кол-во единиц</param>
        /// <returns></returns>
        [Route("AddToCart/{ProductId:int}/{Quantity:int}")]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {

            // получим состав корзины из сессии
            Cart cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart.CartOrderItems.Exists(x => x.ProductId == ProductId))
            {
                cart.CartOrderItems.Where(x => x.ProductId == ProductId).FirstOrDefault().Quantity += Quantity;
            }
            else 
                cart.CartOrderItems.Add(new OrderItem() { ProductId = ProductId, Quantity = Quantity });

            // уберем позиции с нулевым значением количества
            cart.CartOrderItems.RemoveAll(x => x.Quantity <= 0);

            HttpContext.Session.Set<Cart>("Cart", cart);

            //возвращаем на клиент результат добавления и информацию о корзине
            return new JsonResult(new
            {
                result = "ok",
                posCount = cart.CartOrderItems.Count,
                itemCount = cart.CartOrderItems.Sum(x => x.Quantity),
                thisItemNewCount = cart.CartOrderItems.Where(x => x.ProductId == ProductId).FirstOrDefault()?.Quantity
            }) ;
        }
    }
}
