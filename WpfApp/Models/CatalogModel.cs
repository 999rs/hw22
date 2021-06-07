using DomainBasic;
using hw20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp
{
    public class CatalogModel : ICatalogModel
    {
        public event ProductEventHandler ToDeleteProduct;
        public event ProductEventHandler ProductDeleted;
        public event EventHandler ToCreateProduct;
        public event ProductEventHandler ProductCreated;
        public event ProductEventHandler ToUpdateProduct;
        public event ProductEventHandler ProductUpdated;

        public void CreateProduct(Product product)
        {
            DataApiCalls.Products.Create(product);
        }

        public void DeleteProduct(int id)
        {
            DataApiCalls.Products.Delete(id);
        }

        public List<Product> GetAllProducts()
        {
            return DataApiCalls.Products.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return DataApiCalls.Products.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            var res = DataApiCalls.Products.Update(product);

        }
    }
}
