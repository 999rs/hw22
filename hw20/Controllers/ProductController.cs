using DomainBasic;
using EFRepository;
using hw20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly DataContext _context;

        IRepository db;
        


        public ProductController(DataContext context)
        {
            _context = context;
            db = new SQLRepository();
        }

        /// <summary>
        /// информация о продукте
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [Route("ProductAbout/{ProductId:int}")]
        public IActionResult ProductAbout(int ProductId)
        {
            Product product = _context.Products.Where(p => p.Id == ProductId).FirstOrDefault();
            ProductViewModel model = new ProductViewModel(product);
            return View(model);


        }

        [Route("NewProduct")]
        [HttpGet]
        public IActionResult NewProduct()
        {
            var model = new ProductViewModel();
            return View(model);
        
        }

        [Route("NewProduct")]
        [HttpPost]
        public IActionResult NewProduct( [Bind("Product,Upload")] ProductViewModel formModel)
        {
            if (formModel.Upload != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formModel.Upload.CopyTo(ms);
                    formModel.Product.ImageData = ms.ToArray();
                    ModelState.Remove("Product.ImageData");
                    ModelState.Remove("Product.ImagePath");
                    ModelState.Remove("PageContext.HttpContext");
                    ModelState.Remove("PageContext.RouteData");


                }


                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Create(formModel.Product);
                        db.Save();
                        //_context.Add(formModel.Product);
                        //_context.SaveChanges();

                        var folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
                        db.DownloadProdImages(folderPath);
                    }
                    catch (Exception e)
                    {
                        return new JsonResult(new
                        {
                            result = "notOk",
                            message = e.Message,
                            
                        });

                    }
                }
                else 
                {
                    string AllErrorMessages = "";

                    var errors =
                        from item in ModelState
                        where item.Value.Errors.Count > 0
                        select item.Key;
                    var keys = errors.ToArray();


                    foreach (var k in keys)
                    {
                        AllErrorMessages += $"{Environment.NewLine}**{k}**:";
                        foreach (var e in ModelState[k].Errors)
                        {
                            AllErrorMessages += $"    {Environment.NewLine}{e.ErrorMessage}";                           
                        }
                    }

                    
                    return new JsonResult(new
                    {
                        result = "notOk",
                        message = $"Модель невалидна: {AllErrorMessages}",
                        
                    });
                }

            }
            else {
                return new JsonResult(new
                {
                    result = "notOk",
                    message = "Нельзя добавить продукт без файла картинки",
                });
            }


            return new JsonResult(new
            {
                result = "ok",     
                message = "Продукт добавлен",
            });

        }


        [Route("Edit/{ProductId:int}")]
        [HttpGet]
        public IActionResult Edit(int ProductId)
        {
            //var model = new ProductViewModel();
            //var model = new ProductViewModel();

            var model = db.GetProduct(ProductId);

            var viewmodel = new ProductViewModel(model);

            return View(viewmodel);

        }

        [Route("Edit/{ProductId:int}")]
        [HttpPost]
        //[Bind("Id,ProductName,ProductDescription,ProductBasicPrice,ImagePath,ImageData")] Product product
        public IActionResult Edit([Bind("Product,Upload")] ProductViewModel formModel)
        {
            if (formModel.Upload != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formModel.Upload.CopyTo(ms);
                    formModel.Product.ImageData = ms.ToArray();
                    ModelState.Remove("Product.ImageData");
                    ModelState.Remove("Product.ImagePath");
                    ModelState.Remove("PageContext.HttpContext");
                    ModelState.Remove("PageContext.RouteData");


                }


                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Update(formModel.Product);
                        db.Save();
                        //_context.Add(formModel.Product);
                        //_context.SaveChanges();

                        var folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
                        db.DownloadProdImages(folderPath);
                    }
                    catch (Exception e)
                    {
                        return new JsonResult(new
                        {
                            result = "notOk",
                            message = e.Message,

                        });

                    }
                }
                else
                {
                    string AllErrorMessages = "";

                    var errors =
                        from item in ModelState
                        where item.Value.Errors.Count > 0
                        select item.Key;
                    var keys = errors.ToArray();


                    foreach (var k in keys)
                    {
                        AllErrorMessages += $"{Environment.NewLine}**{k}**:";
                        foreach (var e in ModelState[k].Errors)
                        {
                            AllErrorMessages += $"    {Environment.NewLine}{e.ErrorMessage}";
                        }
                    }


                    return new JsonResult(new
                    {
                        result = "notOk",
                        message = $"Модель невалидна: {AllErrorMessages}",

                    });
                }

            }
            else
            {
                return new JsonResult(new
                {
                    result = "notOk",
                    message = "Нельзя добавить продукт без файла картинки",
                });
            }


            return new JsonResult(new
            {
                result = "ok",
                message = "Продукт добавлен",
            });

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
            });
        }

        [Route("Delete/{ProductId:int}")]
        [HttpDelete]
        public IActionResult Delete(int ProductId)
        {
            try
            {
                var prod = _context.Products.Find(ProductId);
                if (prod != null)
                {
                    _context.Products.Remove(prod);
                    _context.SaveChanges();

                    return new JsonResult(new
                    {
                        result = "ok",
                        message = "ok"
                    });
                }
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    result = "error",
                    message = e.Message
                }) ;


            }

            return new JsonResult(new
            {
                result = "notOk"
            });

        }

    }
}
