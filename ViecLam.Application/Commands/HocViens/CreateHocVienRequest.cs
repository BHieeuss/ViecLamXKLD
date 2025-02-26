using MediatR;
using ViecLam.Application.Response;

namespace ViecLam.Application.Commands.HocVien
{
    public class CreateHocVienRequest :  IRequest<ServiceResponse>
    {
        public string HoTen { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string DiaChi { get; set; }
        public int SoCMND { get; set; }
        public DateTime NgayCapCMND { get; set; }
        public int TinhTrangHonNhan { get; set; }
        public int SoDienThoaiTTS { get; set; }
        public int SoDienThoaiNguoiThan { get; set; }
        public int SoDienThoaiCBTD { get; set; }
        public string ThiLucMat { get; set; }
        public string MuMau { get; set; }
        public int ThuanTay { get; set; }
    }
}
