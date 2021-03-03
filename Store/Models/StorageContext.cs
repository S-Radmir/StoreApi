using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
        }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductList> ProductList { get; set; }
    }
}
