using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

namespace SportsStore.Models
{
    public class ProductRepository : IProductRepository
    {
        protected SportStoreDbContext DbContext { get; }

        public ProductRepository(SportStoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Product> Products => DbContext.Products.Include(p => p.Category).ToArray();

        public void AddProduct(Product product)
        {
            DbContext.Add(product);
            DbContext.SaveChanges();
        }

        public Product GetProduct(long key)
        {
            if (key <= 0) throw new ArgumentOutOfRangeException(nameof(key));
            return DbContext.Products.Include(n => n.Category).First(n => n.Id == key);
        }

        public void UpdateProduct(Product product)
        {
            var p = DbContext.Products.Find(product.Id);
            p.Name = product.Name;
            //p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            p.CategoryId = product.CategoryId;
            DbContext.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            var data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline =
                DbContext.Products.Where(p => data.Keys.Contains(p.Id));
            foreach (var databaseProduct in baseline)
            {
                var requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }

            DbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            DbContext.Products.Remove(product);
            DbContext.SaveChanges();
        }
    }
}