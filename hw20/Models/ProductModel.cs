using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    public class ProductModel
    {
        Product Product;
        string modelInfo = "empty";

        ProductModel(int Id)
        {
            this.Product = InMemRepo.ProductsRepo.Where(x => x.ProductId == Id).FirstOrDefault();
        }
    }
}
