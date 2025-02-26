using MediatR;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Commands.HocVien;
using ViecLam.Application.Contracts.Persistances;
using ViecLam.Application.Response;
using ViecLam.Domain.Entities;

namespace ViecLam.Application.Handlers.HocVien
{
    public class CreateHocVienHandler : IRequestHandler<CreateHocVienRequest, ServiceResponse>
    {
        private readonly IHocVienRepository hocVienRepository;
        private readonly ILogger<CreateHocVienHandler> logger;

        public CreateHocVienHandler(IHocVienRepository hocVienRepository, ILogger<CreateHocVienHandler> logger)
        {
            this.hocVienRepository = hocVienRepository;
            this.logger = logger;
        }

        public async Task<ServiceResponse> Handle(CreateHocVienRequest request, CancellationToken cancellationToken)
        {
            await using (var transaction = hocVienRepository.BeginTransaction())
            {
                try
                {
                    // Kiểm tra và xử lý các yêu cầu cho các trường như ảnh nếu có

                    var hocVien = new ViecLam.Domain.Entities.HocVien()
                    {
                        HoTen = request.HoTen,
                        NgayThangNamSinh = request.NgayThangNamSinh,
                        DiaChi = request.DiaChi,
                        SoCMND = request.SoCMND,
                        NgayCapCMND = request.NgayCapCMND,
                        TinhTrangHonNhan = request.TinhTrangHonNhan,
                        SoDienThoaiTTS = request.SoDienThoaiTTS,
                        SoDienThoaiNguoiThan = request.SoDienThoaiNguoiThan,
                        SoDienThoaiCBTD = request.SoDienThoaiCBTD,
                        ThiLucMat = request.ThiLucMat,
                        MuMau = request.MuMau,
                        ThuanTay = request.ThuanTay
                    };

                    // Thêm học viên vào cơ sở dữ liệu
                    await hocVienRepository.AddAsync(hocVien);
                    await hocVienRepository.SaveChangeAsync();
                    await transaction.CommitAsync(cancellationToken);

                    // Tạo phản hồi thành công
                    var response = new ServiceResponse(
                        IsSuccess: true,
                        Message: "Thêm học viên thành công",
                        StatusCode: 201,
                        Data: new List<object> { hocVien }
                    );

                    logger.LogInformation("Thêm học viên thành công với ID: {HocVienId}", hocVien.Id);
                    return response;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    logger.LogError(ex, "Đã xảy ra lỗi khi thêm học viên.");
                    return new ServiceResponse(
                        IsSuccess: false,
                        Message: "Thêm học viên thất bại",
                        StatusCode: 500,
                        Errors: new List<string> { ex.InnerException?.Message ?? ex.Message }
                    );
                }
            }
        }
    }
}
