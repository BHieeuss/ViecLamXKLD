using MediatR;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Commands.HocVien;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Application.Response;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Application.Handlers.HocViens
{
    public class CreateQuaTrinhLamViecHandler : IRequestHandler<CreateQuaTrinhLamViecRequest, ServiceResponse>
    {
        private readonly IQuaTrinhLamViecRepository quaTrinhLamViecRepository;
        private readonly IThongTinHocVienRepository thongTinHocVienRepository;
        private readonly ILogger<CreateQuaTrinhLamViecHandler> logger;

        public CreateQuaTrinhLamViecHandler(
            IQuaTrinhLamViecRepository quaTrinhLamViecRepository,
            IThongTinHocVienRepository thongTinHocVienRepository,
            ILogger<CreateQuaTrinhLamViecHandler> logger)
        {
            this.quaTrinhLamViecRepository = quaTrinhLamViecRepository;
            this.thongTinHocVienRepository = thongTinHocVienRepository;
            this.logger = logger;
        }

        public async Task<ServiceResponse> Handle(CreateQuaTrinhLamViecRequest request, CancellationToken cancellationToken)
        {
            try
            {            
                var quaTrinhLamViec = new QuaTrinhLamViec
                {
                    HocVienId = request.HocVienId,
                    TuNgay = request.TuNgay,
                    DenNgay = request.DenNgay,
                    TenCongTy = request.TenCongTy,
                    NoiDungCongViec = request.NoiDungCongViec
                };

                await quaTrinhLamViecRepository.AddAsync(quaTrinhLamViec);

                await quaTrinhLamViecRepository.SaveChangeAsync();
                return new ServiceResponse(true, "Thêm quá trình làm việc thành công", 201);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Lỗi khi thêm quá trình làm việc");
                return new ServiceResponse(false, "Thêm quá trình làm việc thất bại", 500, new List<string> { ex.Message });
            }
        }
    }
}
