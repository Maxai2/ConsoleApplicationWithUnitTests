using ConsoleApplication.Models;
using ConsoleApplication.Repositories;
using ConsoleApplication.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApplication.Tests
{
    class FakeRepo : IRepository
    {
        private List<Order> orders = new List<Order>
        {
            new Order("as", 1, "Al") { Id = 1, Delivered = true },
                new Order("asdf", 5, "Alas") {Id = 2, Delivered = false },
                new Order("as", 3, "Afl") {Id = 3, Delivered = true },
                new Order("zxcv", 1, "Afzsl") {Id = 4, Delivered = false },
                new Order("qwer", 2, "AflAad") {Id = 5, Delivered = true }
        };

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        public Order GetOrder(int id)
        {
            return this.orders.FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrder(int id, Order order)
        {
            var ord = this.orders.FirstOrDefault(o => o.Id == id);
            ord.Buyer = order.Buyer;
            ord.Count = order.Count;
            ord.Delivered = order.Delivered;
            ord.Product = order.Product;
        }
    }

    public class OrdersTests
    {
        private List<Order> ordersList = new List<Order>
        {
            new Order("as", 1, "Al") { Id = 1, Delivered = true },
                new Order("asdf", 5, "Alas") {Id = 2, Delivered = false },
                new Order("as", 3, "Afl") {Id = 3, Delivered = true },
                new Order("zxcv", 1, "Afzsl") {Id = 4, Delivered = false },
                new Order("qwer", 2, "AflAad") {Id = 5, Delivered = true }
        };

        [Fact]
        public void Test_GetDeliveredOrders_For_Delivered_prop()
        {
            //Arrange
            var repo = new FakeRepo();
            var service = new OrdersService(repo);

            //Act
            var orders = service.GetDeliveredOrders();

            //Assert
            Assert.All(orders, o => Assert.True(o.Delivered));
        }

        //[Fact]
        //public void Test_GetOrders_For_Buyer_Is_Not_Excists_prop()
        //{
        //    //Arrange
        //    var repo = new FakeRepo();
        //    var service = new OrdersService(repo);

        //    //Act
        //    var orders = service.GetOrdersForBuyer("qwe");

        //    //Assert
        //    Assert.Empty(orders);
        //}

        [Fact]
        public void Test_GetOrders_For_Buyer_Is_Not_Excists_prop()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAllOrders()).Returns(ordersList);
            var repo = mock.Object;

            var service = new OrdersService(repo);

            //Act
            var orders = service.GetOrdersForBuyer("qwe");

            //Assert
            Assert.Empty(orders);
        }

        [Fact]
        public void Test_Deliver_Order()
        {
            //Arrange
            var repo = new FakeRepo();
            var service = new OrdersService(repo);

            //Act
            service.DeliverOrder(2);

            //Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_Deliver_Order_with_Param(int id)
        {
            //Arrange
            var repo = new FakeRepo();
            var service = new OrdersService(repo);

            //Act
            service.DeliverOrder(id);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public void Test_Deliver_Order_Does_Not_Excist()
        {
            //Arrange
            var repo = new FakeRepo();
            var service = new OrdersService(repo);

            //Act
            var action = new Action(() => service.DeliverOrder(-150));

            //Assert
            Assert.Throws<KeyNotFoundException>(action);
        }
    }
}