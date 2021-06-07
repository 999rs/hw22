using DomainBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CatalogView.xaml
    /// </summary>
    public partial class CatalogView : Window, ICatalogView
    {
        public CatalogView()
        {
            InitializeComponent();
        }

        

        public event EventHandler ToSelectProduct;
        public event EventHandler ToReloadCatalog;
        public event EventHandler ItemSelected;
        public event ProductEventHandler CatalogList_SelectionChanged;
        public event ProductEventHandler ProductUpdateInitiated;

        public void ProductSelected(Product product)
        {
            ProductDetails.DataContext = product;
            ProductDetails.UpdateLayout();
        }

        public void init()
        {
            Show();
            ToReloadCatalog?.Invoke(this,null);
        }

        public void UpdateCatalog(List<Product> list)
        {
            CatalogList.ItemsSource = list;
        }

        public void AfterProductUpdated(Product product)
        {
            MessageBox.Show("Product Updated");
        }
 

        // no interface

        private void prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CatalogList_SelectionChanged?.Invoke(sender, (e.AddedItems[0] as Product));
            }
        }

        private void LocalUpdateProductClick(object sender, RoutedEventArgs e)
        {
            ProductUpdateInitiated?.Invoke(sender, ProductDetails.DataContext as Product);

        }

    }
}
