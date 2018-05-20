using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

namespace SportsStore.Models
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SportStoreDbContext _dbContext;

        public OrdersRepository(SportStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Order> Orders => _dbContext.Orders.Include(p => p.Lines)
            .ThenInclude(l => l.Product);

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public Order GetOrder(long key)
        {
            return _dbContext.Orders.Include(p => p.Lines).First(n => n.Id == key);
        }
    }
}