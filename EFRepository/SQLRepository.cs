using DomainBasic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EFRepository
{
    public class SQLRepository : IRepository
    {
        private DataContext db;

        public SQLRepository()
        {
            this.db = new DataContext();
        }

        public IEnumerable<Product> GetAllProductList()
        {
            return db.Products;
        }

        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Update(Product item)
        {
            //db.Entry(item).State = EntityState.Modified;
            db.Update(item);
            db.SaveChanges();
        }



        public void Delete(int id)
        {
            Product prod = db.Products.Find(id);

            if (prod != null)
                db.Products.Remove(prod);
        }

        public void Save()
        {

            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DownloadProdImages(string path)
        {
            foreach (var prod in db.Products)
            { 
                
                var file = Path.Combine( path, prod.Id.ToString() + ".jpeg");

                File.WriteAllBytesAsync(file, prod.ImageData);
                

            }
        }

        void IRepository.DownloadImageById(int id, string path)
        {
            var prod = db.Products.Find(id);
            var file = Path.Combine(path, prod.Id.ToString() + ".jpeg");
            File.WriteAllBytesAsync(file, prod.ImageData);
        }
    }
}