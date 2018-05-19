using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Data
{
    public class SportStoreDbContext:DbContext
    {
        public SportStoreDbContext(DbContextOptions<SportStoreDbContext> options) : base(options)
        {

        }

        public  DbSet<Product> Products { get; set; }
    }
}
