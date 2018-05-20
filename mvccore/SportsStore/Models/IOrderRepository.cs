using System.Collections.Generic;

namespace SportsStore.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);

    }
}
