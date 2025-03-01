using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Domain.Entities.HocViens;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Infrastructure.Repositories.HocVien
{
    public class ThongTinHocVienRepository : GenericRepository<ThongTinHocVien>, IThongTinHocVienRepository
    {
        public ThongTinHocVienRepository(AppDbContext dbContext, ILogger<GenericRepository<ThongTinHocVien>> logger, IWebHostEnvironment env) : base(dbContext, logger, env)
        {

        }
    }
}
