using MediatR;
using Microsoft.Extensions.Logging;
using ViecLam.Application.Commands.HocVien;
using ViecLam.Application.Contracts.Persistances.HocVien;
using ViecLam.Application.Response;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Application.Handlers.HocVien
{
    public class CreateHocVienHandler : IRequestHandler<CreateThongTinHocVienRequest, ServiceResponse>
    {
        private readonly IThongTinHocVienRepository hocVienRepository;
        private readonly ILogger<CreateHocVienHandler> logger;

        public CreateHocVienHandler(IThongTinHocVienRepository hocVienRepository, ILogger<CreateHocVienHandler> logger)
        {
            this.hocVienRepository = hocVienRepository;
            this.logger = logger;
        }

        public async Task<ServiceResponse> Handle(CreateThongTinHocVienRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var hocVien = new ThongTinHocVien
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
                    ThuanTay = request.ThuanTay,
                    NhomMau = request.NhomMau,
                    ChieuCao = request.ChieuCao,
                    CanNang = request.CanNang,
                    TonGiao = request.TonGiao,
                    DiemManh = request.DiemManh,
                    DiemYeu = request.DiemYeu,
                    SoThich = request.SoThich,
                    TuNhanXet = request.TuNhanXet,
                    ChuyenMonDaoTao = request.ChuyenMonDaoTao,
                    ThuNhapBanThan = request.ThuNhapBanThan,
                    ThuNhapGiaDinh = request.ThuNhapGiaDinh,
                    LyDoDiNhat = request.LyDoDiNhat,
                    SoTienSau3Nam = request.SoTienSau3Nam,
                    DuDinhSauKhiKetThucHopDong = request.DuDinhSauKhiKetThucHopDong,
                    ChanTayDiTat = request.ChanTayDiTat,
                    DaPhauThuat = request.DaPhauThuat,
                    CoHinhXam = request.CoHinhXam,
                    UongBiaRuou = request.UongBiaRuou,
                    HutThuoc = request.HutThuoc,
                    TienSuBenhLyGiaDinh = request.TienSuBenhLyGiaDinh,
                    KinhNghiemSongTapThe = request.KinhNghiemSongTapThe,
                    BietNauAn = request.BietNauAn,
                    DaTungRaNuocNgoai = request.DaTungRaNuocNgoai,
                    DaLamThuTucVisaNhat = request.DaLamThuTucVisaNhat
                };

                await hocVienRepository.AddAsync(hocVien);
                await hocVienRepository.SaveChangeAsync();

                logger.LogInformation("Thêm học viên thành công với ID: {HocVienId}", hocVien.Id);
                return new ServiceResponse(true, "Thêm học viên thành công", 201, null);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Lỗi khi thêm học viên");
                return new ServiceResponse(false, "Thêm học viên thất bại", 500, new List<string> { ex.Message });
            }
        }
    }
}
