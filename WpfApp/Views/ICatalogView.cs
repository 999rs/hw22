using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainBasic;

namespace WpfApp
{
    /// <summary>
    /// интрефейс для вью каталога
    /// </summary>
    public interface ICatalogView
    {
        /// <summary>
        /// смена выбора на продуктах
        /// </summary>
        event ProductEventHandler CatalogList_SelectionChanged;

        /// <summary>
        /// выбрать продукт
        /// </summary>
        event EventHandler ToSelectProduct;

        /// <summary>
        /// обновить каталог
        /// </summary>
        event EventHandler ToReloadCatalog;

        /// <summary>
        /// обновление продукта
        /// </summary>
        event ProductEventHandler ProductUpdateInitiated;

        /// <summary>
        /// после обновления продукта
        /// </summary>
        /// <param name="product"></param>
        public void AfterProductUpdated(Product product);

        /// <summary>
        /// обновитьть каталог
        /// </summary>
        /// <param name="list"></param>
        public void UpdateCatalog(List<Product> list);

        /// <summary>
        /// продукт выбран
        /// </summary>
        /// <param name="product"></param>
        public void ProductSelected(Product product);

        /// <summary>
        /// инициация вью
        /// </summary>
        public void init();


    }
}
