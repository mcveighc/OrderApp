using BGLOrderApp.Models.Data;
using System;

namespace BGLOrderApp.Models
{
    public class OrderItemDto : ItemDto
    {
        public int Quantity { get; set; }

        public static OrderItemDto FromDbOrderItem(OrderItem dbOrderItem)
        {
            return new OrderItemDto()
            {
                Id = dbOrderItem.ItemId,
                Name = dbOrderItem.Item.Name,
                Description = dbOrderItem.Item.Description,
                Price = dbOrderItem.Item.Price,
                Quantity = dbOrderItem.ItemQuantity,
                Status = Enum.Parse<StatusType>(dbOrderItem.Item.Status.ToString())
            };
        }
    }
}