﻿using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    public class ProductViewModel
    {
        public Product Product;
        public string modelInfo = "empty";

        public ProductViewModel(int Id)
        {
            this.Product = InMemRepo.ProductsRepo.Where(x => x.ProductId == Id).FirstOrDefault();
        }
    }
}