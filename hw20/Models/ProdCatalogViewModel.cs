using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// Корзина
        /// </summary>
        public Cart Cart = new Cart();

        public ProdCatalogViewModel()
        {
            Products = InMemRepo.ProductsRepo;
        }
    }
}
