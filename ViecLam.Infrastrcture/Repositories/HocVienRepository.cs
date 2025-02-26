using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Contracts.Persistances;
using ViecLam.Domain.Entities;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Infrastructure.Repositories
{
    public class HocVienRepository : GenericRepository<HocVien>, IHocVienRepository
    {
        public HocVienRepository(AppDbContext dbContext, ILogger<GenericRepository<HocVien>> logger, IWebHostEnvironment env) : base(dbContext, logger, env)
        {

        }
    }
}
