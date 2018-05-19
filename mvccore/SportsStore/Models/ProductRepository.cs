using System.Collections.Generic;
using System.Linq;
using SportsStore.Data;

namespace SportsStore.Models
{
    public class ProductRepository : IRepository
    {
        protected SportStoreDbContext DbContext { get; }

        public ProductRepository(SportStoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Product> Products => DbContext.Products.ToArray();

        public void AddProduct(Product product)
        {
            DbContext.Add(product);
            DbContext.SaveChanges();
        }
    }
}