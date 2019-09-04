using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreIncludeDemo.Models
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Model1> Model1s { get; set; }
        public DbSet<Model2> Model2s { get; set; }
        public DbSet<Model3> Model3s { get; set; }

    }
}
