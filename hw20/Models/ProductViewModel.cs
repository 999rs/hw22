using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    /// <summary>
    /// вьюмодель продукта
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// продукт
        /// </summary>
        public Product Product;
        public string modelInfo = "empty";

        public ProductViewModel(int Id)
        {
            this.Product = InMemRepo.ProductsRepo.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
