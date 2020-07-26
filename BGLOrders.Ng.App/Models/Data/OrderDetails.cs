using System;
using System.Collections.Generic;
using System.Text;

namespace BGLOrderApp.Models.Data
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ItemQuantity { get; set; }
    }
}
