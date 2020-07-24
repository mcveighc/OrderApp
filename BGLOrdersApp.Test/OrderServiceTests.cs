using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using FluentAssertions;
using BGLOrderApp.Models;
using BGLOrderApp.Data.Repositories;
using BGLOrderApp.Models.Data;
using BGLOrderApp.Services;

namespace BGLOrdersApp.Api.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void CreateOrder_CreatedDate_Should_BeStoredInUtcFormat()
        {
            // Arrange
            var dateToTest = DateTime.Now;
            var inputDto = new NewOrderDto() { CreatedDate = dateToTest };
            var mockOrderRepository = new Mock<IOrderRepository>();

            var result = default(Order);
            mockOrderRepository.Setup(r => r.Create(It.IsAny<Order>()))
                               .Callback<Order>(o => result = o);

            // Act
            var orderService = new OrderService(mockOrderRepository.Object);
            orderService.Add(inputDto);

            // Assert
            mockOrderRepository.Verify(orderRepo => orderRepo.Create(It.IsAny<Order>()), Times.Once);
            Assert.AreEqual(result.CreatedDate, dateToTest.ToUniversalTime());
        }

        [TestMethod]
        public void CreateOrder_ShouldMapProperties_To_DbOrder()
        {
            // Arrange
            var dateToTest = DateTime.Now;
            var inputDto = new NewOrderDto() { Total = 100, CreatedDate = dateToTest };

            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderForPersistance = default(Order);
            mockOrderRepository.Setup(r => r.Create(It.IsAny<Order>())).Callback<Order>(o => orderForPersistance = o);

            // Act
            var orderService = new OrderService(mockOrderRepository.Object);
            orderService.Add(inputDto);

            // Assert
            var dbOrder = new Order { Total = 100, UserId = -1, OrderItems = new List<OrderItem>(), CreatedDate = dateToTest.ToUniversalTime() };
            mockOrderRepository.Verify(moqRepo => moqRepo.Create(It.IsAny<Order>()), Times.Once);
            dbOrder.Should().BeEquivalentTo(orderForPersistance);
        }
    }
}
