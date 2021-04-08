using System;
using System.Collections.Generic;
using System.Text;

namespace DomainBasic
{
    public class Order
    {
        public int OrderId;
        public List<OrderItem> OrderItems = new List<OrderItem>();

    }
}
