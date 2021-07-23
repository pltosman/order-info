using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using OrderInfo.Business.Concrete;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.Entities.Concrete;
using Xunit;

namespace OrderInfo.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetsLatestOrderByCustomerId()
        {
            
            var customerId = "A99001";
            var expectedOrderId = 9;
           
            var orderDate = Convert.ToDateTime("2020-12-03");

            var latestOrder = new Order
            {
                OrderId = expectedOrderId,
                CustomerId = customerId,
                OrderDate = orderDate,
                DeliveryExpected = Convert.ToDateTime("2021-05-27"),
                ContainGift = false,
                ShippingMode = "Courier",
                OrderSource = "WEB"
            };

            var oldOrder = new Order
            {
                OrderId = 8,
                CustomerId = customerId,
                OrderDate = Convert.ToDateTime("2020-04-05"),
                DeliveryExpected = Convert.ToDateTime("2021-05-27"),
                ContainGift = true,
                ShippingMode = "Courier",
                OrderSource = "WEB"
            };


            var mock = new Mock<IOrderDal>();

            mock.Setup(x => x.GetList(It.IsAny<Expression<Func<Order, bool>>>())).Returns(new List<Order>() { latestOrder, oldOrder});

            var service = new OrderManager(mock.Object);
            var result = service.GetLatestOrderByCustomerId(customerId);

            Assert.Equal(latestOrder.OrderId, result.Data.OrderId);
            Assert.Equal(latestOrder.OrderDate, result.Data.OrderDate);

        }

        [Fact]
        public  async Task GetsItemsByOrderId()
        {
            var expectedFirstOrderItemId = 12;
            var expectedSecondOrderItemId = 14;
            int? expectedOrderId = 9;

            var firstProduct = new Product
            {
                ProductId = expectedFirstOrderItemId,
                ProductName = "I love my pet",
                PackHeight = (decimal?)11.30,
                PackWidth = (decimal?)3.20,
                PackWeight = (decimal?)0.932,
                Colour = "Cyan",
                Size = "S"

            };


            var secondProduct = new Product
            {
                ProductId = expectedSecondOrderItemId,
                ProductName = "I love my pet",
                PackHeight = (decimal?)11.30,
                PackWidth = (decimal?)3.20,
                PackWeight = (decimal?)0.932,
                Colour = "Cyan",
                Size = "L"

            };


            var firstItem = new OrderItem { OrderItemId = expectedFirstOrderItemId, OrderId = 9, ProductId = 12, Product = firstProduct, Quantity = 1, Price = (decimal?)11.99, Returnable = false };
            var secondItem = new OrderItem { OrderItemId = expectedSecondOrderItemId, OrderId = 9, ProductId = 14, Product = secondProduct, Quantity = 1, Price = null, Returnable = null };

            var orderItems = new List<OrderItem>() { firstItem, secondItem };

            var mock = new Mock<IOrderItemDal>();

            mock.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<OrderItem, bool>>>(), It.IsAny<Expression<Func<OrderItem, object>>[]>())).ReturnsAsync(orderItems);

            var service = new OrderItemManager(mock.Object);
            var result = await service.GetListWithProductsByOrderIdAsync((int)expectedOrderId);

            Assert.All(result.Data,item=> Assert.Equal(expectedOrderId,item.OrderId));
          
        }
    }
}
