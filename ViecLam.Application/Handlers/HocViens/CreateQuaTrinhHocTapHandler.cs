using MediatR;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Commands.HocVien;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Application.Response;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Application.Handlers.HocViens
{
    public class CreateQuaTrinhHocTapHandler : IRequestHandler<CreateQuaTrinhHocTapRequest, ServiceResponse>
    {
        private readonly IQuaTrinhHocTapRepository quaTrinhHocTapRepository;
        private readonly IThongTinHocVienRepository thongTinHocVienRepository;
        private readonly ILogger<CreateQuaTrinhHocTapHandler> logger;

        public CreateQuaTrinhHocTapHandler(
            IQuaTrinhHocTapRepository quaTrinhHocTapRepository,
            IThongTinHocVienRepository thongTinHocVienRepository,
            ILogger<CreateQuaTrinhHocTapHandler> logger)
        {
            this.quaTrinhHocTapRepository = quaTrinhHocTapRepository;
            this.thongTinHocVienRepository = thongTinHocVienRepository;
            this.logger = logger;
        }

        public async Task<ServiceResponse> Handle(CreateQuaTrinhHocTapRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var quaTrinhHocTap = new QuaTrinhHocTap
                    {
                        HocVienId = request.HocVienId,
                        TuNgay = request.TuNgay,
                        DenNgay = request.DenNgay,
                        TenTruong = request.TenTruong,
                        ChuyenNganhDaoTao = request.ChuyenNganhDaoTao
                    };

                await quaTrinhHocTapRepository.AddAsync(quaTrinhHocTap);

                await quaTrinhHocTapRepository.SaveChangeAsync();
                return new ServiceResponse(true, "Thêm quá trình học tập thành công", 201);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Lỗi khi thêm quá trình làm việc");
                return new ServiceResponse(false, "Thêm quá trình làm việc thất bại", 500, new List<string> { ex.Message });
            }
        }
    }
}
