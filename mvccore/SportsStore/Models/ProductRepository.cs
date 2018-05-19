using System;
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

        public Product GetProduct(long key)
        {
            if (key <= 0) throw new ArgumentOutOfRangeException(nameof(key));
            return DbContext.Products.Find(key);
        }

        public void UpdateProduct(Product product)
        {
            //var p = GetProduct(product.Id);
            //p.Name = product.Name;
            //p.Category = product.Category;
            //p.PurchasePrice = product.PurchasePrice;
            //p.RetailPrice = product.RetailPrice;
            DbContext.Products.Update(product);
            DbContext.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            DbContext.Products.UpdateRange(products);
            DbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            this.DbContext.Products.Remove(product);
            DbContext.SaveChanges();
        }
    }
}