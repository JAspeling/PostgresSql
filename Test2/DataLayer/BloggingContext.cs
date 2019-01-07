using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DomainModels;
using DataLayer.ErrorHandling;

namespace DataLayer {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=test;Username=postgres;Password=Zaq12wsx");
        }
    }
}
