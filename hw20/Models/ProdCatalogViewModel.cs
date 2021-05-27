using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace hw20.Models
{
    /// <summary>
    /// вьюмодель каталога
    /// </summary>
    public class ProdCatalogViewModel
    {
        /// <summary>
        /// список продуктов
        /// </summary>
        public List<Product> Products = new List<Product>();

        /// <summary>
        /// справочник путей картинок
        /// </summary>
        public Dictionary<int, string> ProductImages = new Dictionary<int, string>();

        /// <summary>
        /// Корзина
        /// </summary>
        public Cart Cart = new Cart();
        
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="productList"></param>
        public ProdCatalogViewModel(IEnumerable<Product> productList)
        {
            Products = productList.ToList();
            foreach (var p in Products)
            {

                ProductImages.Add(p.Id, $"~/Img/Products/{p.Id}.jpeg");
            }

        }
    }
}
