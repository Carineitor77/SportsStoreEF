using System.Collections.Generic;

namespace Chapter4.Models
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Orders { get; }
        Order GetOrder(long key);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
