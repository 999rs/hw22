using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    public class ProdCatalogViewModel
    {
        public List<Product> Products = new List<Product>();

        public ProdCatalogViewModel()
        {
            Products = InMemRepo.ProductsRepo;
        }
    }
}
