using ConsoleApplication.Models;
using System.Collections.Generic;

namespace ConsoleApplication.Services
{
    public interface IOrderServer
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetDeliveredOrders();
        IEnumerable<Order> GetNotDeliveredOrders();
        IEnumerable<Order> GetOrdersForBuyer(string buyer);
        IEnumerable<Order> GetOrdersForProduct(string product);

        Order FindOrder(int id);
        void PlaceNewOrder(string product, int count, string buyer);
        void CancelOrder(int id);
        void DeliverOrder(int id);
    }
}
