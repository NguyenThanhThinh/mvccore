using System.Collections.Generic;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace SportsStore.Models
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
