using BGLOrderApp.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace BGLOrderApp.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();
        OrderDto Get(int id);
        void Add(NewOrderDto order);
        void Remove(int id);
        void Update(int id, string value);
    }
}