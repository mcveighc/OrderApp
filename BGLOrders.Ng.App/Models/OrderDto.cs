using BGLOrderApp.Models.Data;
using BGLOrderApp.Models.Links;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BGLOrderApp.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }

        // Hypermedia links for self describing API
        public IList<ILink> Links { get; set; }

        public OrderDto()
        {
            Items = new List<OrderItemDto>();
            Links = new List<ILink>();
        }

        public static OrderDto FromDbOrder(Order dbOrder)
        {
            return new OrderDto()
            {
                Id = dbOrder.Id,
                Total = dbOrder.Total,
                UserId = dbOrder.UserId,
                CreatedDate = dbOrder.CreatedDate.ToLocalTime(),
                Items = dbOrder.OrderItems.Select(oi => OrderItemDto.FromDbOrderItem(oi)),
                Links = dbOrder.OrderItems.Select(i => new ItemLink(i.ItemId) as ILink).ToList()
            };
        }
    }
}
