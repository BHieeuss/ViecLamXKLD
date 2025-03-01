using ViecLam.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViecLam.Application.Contracts.Persistances;
using ViecLam.Infrastructure.Repositories;
using ViecLam.Infrastructure.Repositories.HocVien;
using ViecLam.Application.Contracts.Persistances.HocVien;

namespace ViecLam.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Adds the AppDbContext with SQL Server configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Registers the Blog
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IThongTinHocVienRepository, ThongTinHocVienRepository>();
            services.AddScoped<IQuaTrinhHocTapRepository, QuaTrinhHocTapRepository>();
            services.AddScoped<IQuaTrinhLamViecRepository, QuaTrinhLamViecRepository>();
            services.AddScoped<IThanhPhanGiaDinhRepository, ThanhPhanGiaDinhRepository>();
            return services;
        }
    }
}
