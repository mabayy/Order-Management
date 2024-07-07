using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Order_Management
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
