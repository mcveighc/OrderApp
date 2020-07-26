using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BGLOrderApp.Models.Data
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public IList<OrderItem> OrderDetails { get; set; }

        public Item()
        {
            OrderDetails = new List<OrderItem>();
        }
        public static Item FromItemDto(ItemDto itemDto)
        {
            return new Item()
            {
                Id = itemDto.Id,
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = Convert.ToDecimal(itemDto.Price),
                Status = (int)itemDto.Status
            };

        }
    }
}
