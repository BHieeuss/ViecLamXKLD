using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ThongTinHocVien> ThongTinHocViens { get; set; }
        public DbSet<QuaTrinhHocTap> QuaTrinhHocTaps { get; set; }
        public DbSet<QuaTrinhLamViec> QuaTrinhLamViecs { get; set; }
        public DbSet<ThanhPhanGiaDinh> ThanhPhanGiaDinhs { get; set; }
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
