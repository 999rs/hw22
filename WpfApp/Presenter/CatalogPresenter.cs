using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainBasic;

namespace WpfApp.Presenter
{
    /// <summary>
    /// Presenter
    /// </summary>
    public class CatalogPresenter
    {
        /// <summary>
        /// модель
        /// </summary>
        public ICatalogModel model;

        /// <summary>
        /// вью
        /// </summary>
        public ICatalogView view;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        public CatalogPresenter(ICatalogModel m, ICatalogView v)
        {
            model = m;
            view = v;

            view.ToReloadCatalog += View_ToReloadCatalog;
            view.CatalogList_SelectionChanged += View_CatalogList_SelectionChanged;
            view.ProductUpdateInitiated += View_ProductUpdateInitiated;
            
        }

        /// <summary>
        /// запрос на обновление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="p"></param>
        private void View_ProductUpdateInitiated(object sender, Product p)
        {
            model.UpdateProduct(p); // api
            view.AfterProductUpdated(p); // show msg
            var list = model.GetAllProducts();
            view.UpdateCatalog(list);
        }

        /// <summary>
        /// смена выделенного продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CatalogList_SelectionChanged(object sender, Product e)
        {
            var product = model.GetProductById(e.Id);
            view.ProductSelected(product);
        }


        /// <summary>
        /// обновить каталог 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_ToReloadCatalog(object sender, EventArgs e)
        {
            var list = model.GetAllProducts();
            view.UpdateCatalog(list);
        }

        /// <summary>
        /// инициация представления
        /// </summary>
        public void init() 
        {

            view.init();
        }
    }
}
