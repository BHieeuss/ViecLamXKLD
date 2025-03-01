using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Domain.Entities.HocViens;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Infrastructure.Repositories.HocVien
{
    public class QuaTrinhLamViecRepository : GenericRepository<QuaTrinhLamViec>, IQuaTrinhLamViecRepository
    {
        public QuaTrinhLamViecRepository(AppDbContext dbContext, ILogger<GenericRepository<QuaTrinhLamViec>> logger, IWebHostEnvironment env) : base(dbContext, logger, env)
        {

        }
    }
}
