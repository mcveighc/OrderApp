using BGLOrderApp.Data.Repositories;
using BGLOrderApp.Models;
using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BGLOrderApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDto Get(int id)
        {
            var dbOrder = _orderRepository.Get(id);
            return dbOrder == null ? null : OrderDto.FromDbOrder(dbOrder);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var dbOrders = _orderRepository.GetAll();
            var orderDtos = dbOrders.Select(dbo => OrderDto.FromDbOrder(dbo));

            return orderDtos;
        }

        public void Add(NewOrderDto order)
        {
            var dbOrder = new Order()
            {
                CreatedDate = order.CreatedDate.ToUniversalTime(),
                Total = order.Total,
                UserId = -1,
            };

            dbOrder.OrderItems = GetOrderItems(order.Items, dbOrder);

            _orderRepository.Create(dbOrder);
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        private IList<OrderItem> GetOrderItems(IEnumerable<OrderItemDto> items, Order o)
        {
            return items.Select(i => new OrderItem()
            {
                Order = o,
                ItemId = i.Id,
                ItemQuantity = i.Quantity
            }).ToList();
        }

        public void Remove(int id)
        {
            this._orderRepository.Delete(id);
        }

        public void Update(int id, string value)
        {
            throw new NotImplementedException();
        }
    }
}
