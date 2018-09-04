using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Models;
using ConsoleApplication.Repositories;

namespace ConsoleApplication.Services
{
    public class OrdersService : IOrderServer
    {
        private readonly IRepository repo;

        public OrdersService(IRepository repo)
        {
            this.repo = repo;
        }

        public void CancelOrder(int id)
        {
            this.repo.DeleteOrder(id);
        }

        public void DeliverOrder(int id)
        {
            var order = this.repo.GetOrder(id);

            if (order == null)
                throw new KeyNotFoundException();

            order.Delivered = true;
            this.repo.UpdateOrder(id, order);
        }

        public Order FindOrder(int id)
        {
            var order = this.repo.GetOrder(id);
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = this.repo.GetAllOrders();
            return orders;
        }

        public IEnumerable<Order> GetDeliveredOrders()
        {
            var orders = this.repo.GetAllOrders().Where(o => o.Delivered == true);
            return orders;
        }

        public IEnumerable<Order> GetNotDeliveredOrders()
        {
            var orders = this.repo.GetAllOrders().Where(o => o.Delivered == false);
            return orders;
        }

        public IEnumerable<Order> GetOrdersForBuyer(string buyer)
        {
            var orders = this.repo.GetAllOrders().Where(o => o.Buyer == buyer);
            return orders;
        }

        public IEnumerable<Order> GetOrdersForProduct(string product)
        {
            var orders = this.repo.GetAllOrders().Where(o => o.Product == product);
            return orders;
        }

        public void PlaceNewOrder(string product, int count, string buyer)
        {
            var order = new Order(product, count, buyer);
            this.repo.AddOrder(order);
        }
    }
}
