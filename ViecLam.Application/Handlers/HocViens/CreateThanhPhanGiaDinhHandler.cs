using MediatR;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Commands.HocVien;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Application.Response;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Application.Handlers.HocViens
{
    public class CreateThanhPhanGiaDinhHandler : IRequestHandler<CreateThanhPhanGiaDinhRequest, ServiceResponse>
    {
        private readonly IThanhPhanGiaDinhRepository thanhPhanGiaDinhRepository;
        private readonly IThongTinHocVienRepository thongTinHocVienRepository;
        private readonly ILogger<CreateThanhPhanGiaDinhHandler> logger;

        public CreateThanhPhanGiaDinhHandler(
            IThanhPhanGiaDinhRepository quaTrinhHocTapRepository,
            IThongTinHocVienRepository thongTinHocVienRepository,
            ILogger<CreateThanhPhanGiaDinhHandler> logger)
        {
            this.thanhPhanGiaDinhRepository = thanhPhanGiaDinhRepository;
            this.thongTinHocVienRepository = thongTinHocVienRepository;
            this.logger = logger;
        }

        public async Task<ServiceResponse> Handle(CreateThanhPhanGiaDinhRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var thanhPhanGiaDinh = new ThanhPhanGiaDinh
                {
                    HocVienId = request.HocVienId,
                    HoTen = request.HoTen,
                    QuanHe = request.QuanHe,
                    Tuoi = request.Tuoi,
                    NgheNghiep = request.NgheNghiep,
                    SongChung = request.SongChung
                };

                await thanhPhanGiaDinhRepository.AddAsync(thanhPhanGiaDinh);

                await thanhPhanGiaDinhRepository.SaveChangeAsync();
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
