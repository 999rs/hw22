using DomainBasic;
using System;
using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// интерфейс модели
    /// </summary>
    public  interface ICatalogModel
    {
        /// <summary>
        /// получить лист продуктов
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// продукт по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id);

        /// <summary>
        /// создать продукт
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(Product product);

        /// <summary>
        /// обновить
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product);

        /// <summary>
        /// удалить
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id);

        #region EVENTS
        
        /// <summary>
        /// продукти удален
        /// </summary>
        public event ProductEventHandler ProductDeleted;

        /// <summary>
        /// создание продукта
        /// </summary>
        public event EventHandler ToCreateProduct;

        /// <summary>
        /// продукт создагн
        /// </summary>
        public event ProductEventHandler ProductCreated;

        /// <summary>
        /// обновить продукт
        /// </summary>
        public event ProductEventHandler ToUpdateProduct;

        /// <summary>
        /// продукт обновлен
        /// </summary>
        public event ProductEventHandler ProductUpdated;

        #endregion EVENTS
    }

    /// <summary>
    /// аргумент для событий с продуктом
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="p"></param>
    public delegate void ProductEventHandler(object sender, Product p);
}