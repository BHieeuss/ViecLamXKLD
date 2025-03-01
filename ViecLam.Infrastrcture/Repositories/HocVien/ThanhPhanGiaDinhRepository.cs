using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Domain.Entities.HocViens;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Infrastructure.Repositories.HocVien
{
    public class ThanhPhanGiaDinhRepository : GenericRepository<ThanhPhanGiaDinh>, IThanhPhanGiaDinhRepository
    {
        public ThanhPhanGiaDinhRepository(AppDbContext dbContext, ILogger<GenericRepository<ThanhPhanGiaDinh>> logger, IWebHostEnvironment env) : base(dbContext, logger, env)
        {

        }
    }
}
