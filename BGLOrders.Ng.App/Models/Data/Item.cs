using System.Collections.Generic;

namespace BGLOrderApp.Models.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public IList<OrderItem> OrderDetails { get; set; }
    }
}
