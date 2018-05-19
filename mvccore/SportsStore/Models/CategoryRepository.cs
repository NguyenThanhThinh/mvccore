using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    using SportsStore.Models;
    using SportsStore.Data;

    public class CategoryRepository : ICategoryRepository
    {
        private SportStoreDbContext _dbContext;

        public CategoryRepository(SportStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Category> Categories => _dbContext.Categories.ToArray();

        public void AddCategogy(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}