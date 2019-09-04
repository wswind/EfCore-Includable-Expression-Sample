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

        public DbSet<Model1> Model1S { get; set; }
        public DbSet<Model2> Model2S { get; set; }
        public DbSet<Model3> Model3S { get; set; }
        public DbSet<Model4> Model4S { get; set; }

    }
}
