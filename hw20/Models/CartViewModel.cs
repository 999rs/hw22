using DomainBasic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw20.Models
{
    /// <summary>
    /// вьюмодель корзины
    /// </summary>
    public class CartViewModel
    {
        /// <summary>
        /// корзина
        /// </summary>
        public Cart Cart;

        public List<Product> Products;

        public Dictionary<int, string> ProductImages = new Dictionary<int, string>();

        public CartViewModel(Cart cart, List<Product> products)
        {
            this.Cart = cart;
            this.Products = products;
            var ProdIds = Cart.CartOrderItems.Select(x => x.ProductId);

            foreach (var p in ProdIds)
            {
                // p.ImagePath = $"~/Img/Products/{p.Id}.jpeg";

                ProductImages.Add(p, $"~/Img/Products/{p}.jpeg");
                
            }

        }

    }
}
