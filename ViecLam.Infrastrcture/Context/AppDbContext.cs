using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ViecLam.Domain.Entities;

namespace ViecLam.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<HocVien> HocVien { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
