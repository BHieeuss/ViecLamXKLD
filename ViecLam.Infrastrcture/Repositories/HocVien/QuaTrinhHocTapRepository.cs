using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Domain.Entities.HocViens;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Infrastructure.Repositories.HocVien
{
    public class QuaTrinhHocTapRepository : GenericRepository<QuaTrinhHocTap>, IQuaTrinhHocTapRepository
    {
        public QuaTrinhHocTapRepository(AppDbContext dbContext, ILogger<GenericRepository<QuaTrinhHocTap>> logger, IWebHostEnvironment env) : base(dbContext, logger, env)
        {

        }
    }
}
