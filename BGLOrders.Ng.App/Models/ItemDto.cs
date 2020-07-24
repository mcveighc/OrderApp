using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public StatusType Status { get; set; }

        public static ItemDto FromDbItem(Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Status = Enum.Parse<StatusType>(item.Status.ToString())
            };
        }

    }

    public enum StatusType
    {
        InStock = 0,
        OutOfStock = 1,
        Decomissioned = 2
    }
}
