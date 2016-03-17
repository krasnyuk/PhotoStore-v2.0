using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Entities;
using System.Data.Entity;

namespace PhotosStore.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<PhotoTechnique> PhotoTechniques { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
