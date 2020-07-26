using BGLOrderApp.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace BGLOrderApp.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _dbContext;

        public OrderRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order dbOrder)
        {
            _dbContext.Orders.Add(dbOrder);

            _dbContext.SaveChanges();
        }

        public Order Get(int key)
        {
            return _dbContext.Orders.SingleOrDefault(o => o.Id == key);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }

        public IEnumerable<Order> GetOrderByUserId(int userId)
        {
            return _dbContext.Orders.Where(o => o.UserId == userId);
        }

        public void Update(Order model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var order = new Order() { Id = key };
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
