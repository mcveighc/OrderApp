using BGLOrderApp.Models.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BGLOrderApp.Data.Repositories
{
    public interface IOrderRepository : IRepository<int, Order>
    {
        //IEnumerable<Order> GetOrderByUserId(int userId);
        void Create(Order dborder);
    }
}