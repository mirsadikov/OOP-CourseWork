using Microsoft.EntityFrameworkCore;
using OnlineCarAuction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Car> Car { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=w00012860;Integrated Security=True;Pooling=False");
            }
        }
    }
}
