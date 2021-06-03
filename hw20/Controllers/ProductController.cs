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

        // репозиторий
        IRepository db;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="context">контекст</param>
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

        /// <summary>
        /// добавление продукта - открытие формы
        /// </summary>
        /// <returns></returns>
        [Route("NewProduct")]
        [HttpGet]
        public IActionResult NewProduct()
        {
            var model = new ProductViewModel();
            return View(model);
        
        }

        /// <summary>
        /// добавление продукта - отправка данных
        /// </summary>
        /// <param name="formModel"></param>
        /// <returns></returns>
        [Route("NewProduct")]
        [HttpPost]
        public IActionResult NewProduct( [Bind("Product,Upload")] ProductViewModel formModel)
        {
            // если приложили файл
            if (formModel.Upload != null)
            {
                // запишем файл в экземпляр
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
                        // пробуем сохранить в базу
                        //db.Create(formModel.Product);
                        //db.Save();
                        DataApiCalls.Products.Create(formModel.Product);
                        
                        // загружаем картинку на диск
                        var folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
                        formModel.Product.DownloadImage(folderPath);
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
                    // сформируем сообщение для показа пользователю
                    string AllErrorMessages = "";

                    var errors =
                        from item in ModelState
                        where item.Value.Errors.Count > 0
                        select item.Key;
                    var keys = errors.ToArray();


                    // перечислим ошибки валидации
                    foreach (var k in keys)
                    {
                        AllErrorMessages += $"{Environment.NewLine}**{k}**:";
                        foreach (var e in ModelState[k].Errors)
                        {
                            AllErrorMessages += $"    {Environment.NewLine}{e.ErrorMessage}";                           
                        }
                    }

                    // отправим резултьтат клиенту
                    return new JsonResult(new
                    {
                        result = "notOk",
                        message = $"Модель невалидна: {AllErrorMessages}",
                        
                    });
                }

            }
            else {
                // добавление без картинки недопустимо
                return new JsonResult(new
                {
                    result = "notOk",
                    message = "Нельзя добавить продукт без файла картинки",
                });
            }

            // сообщим об успешной операции
            return new JsonResult(new
            {
                result = "ok",     
                message = "Продукт добавлен",
            });

        }


        /// <summary>
        /// редактирование продукта - форма
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [Route("Edit/{ProductId:int}")]
        [HttpGet]
        public IActionResult Edit(int ProductId)
        {

            // сформируем вьюмодель
            var model = db.GetProduct(ProductId);
            var viewmodel = new ProductViewModel(model);

            return View(viewmodel);

        }

        /// <summary>
        /// редактирование продукта - отправка
        /// </summary>
        /// <param name="formModel"></param>
        /// <returns></returns>
        [Route("Edit/{ProductId:int}")]
        [HttpPost]
        
        public IActionResult Edit([Bind("Product,Upload")] ProductViewModel formModel)
        {
            ModelState.Remove("PageContext.HttpContext");
            ModelState.Remove("PageContext.RouteData");
            ModelState.Remove("Product.ImageData");

            // если картинку приложили
            if (formModel.Upload != null)
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    formModel.Upload.CopyTo(ms);
                    formModel.Product.ImageData = ms.ToArray();
                }
            }


            if (ModelState.IsValid)
            {
                try
                {
                    // обновим репозиторий
                    db.Update(formModel.Product);

                    //скачаем каритнку
                    var folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
                    db.DownloadImageById(formModel.Product.Id, folderPath);
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

            else // если не валидна модель
            {
                string AllErrorMessages = "";

                var errors =
                    from item in ModelState
                    where item.Value.Errors.Count > 0
                    select item.Key;
                var keys = errors.ToArray();


                // перечислим ошибки валидации
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


            string msgText = "Продукт обновлен.";
            if (formModel.Upload == null)
                msgText += Environment.NewLine + "Картинка не была выбрана и оставлена без изменений";

            // отправим результат
            return new JsonResult(new
            {
                result = "ok",
                message = msgText,
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

        /// <summary>
        /// удаление продукта из каталога
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [Route("Delete/{ProductId:int}")]
        [HttpDelete]
        public IActionResult Delete(int ProductId)
        {
            try
            {
                //var prod = _context.Products.Find(ProductId);
                var prod = db.GetProduct(ProductId);
                if (prod != null)
                {
                    db.Delete(ProductId);
                    db.Save();

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
