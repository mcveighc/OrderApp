using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGLOrderApp.Data.Repositories
{
    public interface IItemRepository : IRepository<int, Item>
    {
        IEnumerable<Item> GetItemsForOrder(int orderId);
    }
}
