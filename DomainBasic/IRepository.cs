using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainBasic;
using Microsoft.EntityFrameworkCore;

namespace DomainBasic
{
    public interface IRepository: IDisposable
    {

        
        public IEnumerable<Product> GetAllProductList();
        public Product GetProduct(int id);
        public void Create(Product item);
        public void Update(Product item);
    
        public void Delete(int id);
        public void Save();
        public void DownloadProdImages(string path);
        public void DownloadImageById(int id, string path);
    }
}
