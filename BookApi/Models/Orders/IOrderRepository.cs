using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IOrderRepository
    {
        List<Orders> GetOrder();
        void AddOrder(Orders order, int orderId);
        void DeleteOrder(int orderId); 
        void UpdateOrder(Orders order);
        int GetOrderId();
    }
}
