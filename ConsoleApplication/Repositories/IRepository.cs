using ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Repositories
{
    public interface IRepository
    {
        void AddOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(int id, Order order);

        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
    }
}   
