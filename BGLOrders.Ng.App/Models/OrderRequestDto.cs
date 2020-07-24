using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Models
{
    public class NewOrderDto
    {
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public OrderItemDto[] Items { get; set; }

        public NewOrderDto()
        {
            Items = new List<OrderItemDto>().ToArray();
        }
    }
}
