using BGLOrderApp.Models.Data;
using BGLOrderApp.Models.Links;
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
        public string Price { get; set; }
        public StatusType Status { get; set; }
        public List<ILink> Links { get; set; }

        public static ItemDto FromDbItem(Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price.ToString(),
                Status = Enum.Parse<StatusType>(item.Status.ToString()),
                Links = item.OrderDetails.Select(od => new OrderLink(od.OrderId) as ILink).ToList()
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
