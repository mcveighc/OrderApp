using BGLOrderApp.Data;
using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGLOrderApp.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly OrdersDbContext _dbContext;

        public ItemRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
        }

        public Item Get(int key)
        {
            return _dbContext.Items.SingleOrDefault(i => i.Id == key);
        }

        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items.ToList();
        }

        public void Update(Item model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var itemToRemove = new Item() { Id = key };
            _dbContext.Remove(itemToRemove);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Item> GetItemsForOrder(int orderId)
        {
            var itemsForOrder = _dbContext.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => od.Item);

            return itemsForOrder;
        }
    }
}
