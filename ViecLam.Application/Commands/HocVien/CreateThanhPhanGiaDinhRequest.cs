using MediatR;
using ViecLam.Application.Response;

namespace ViecLam.Application.Commands.HocVien
{
    public class CreateThanhPhanGiaDinhRequest : IRequest<ServiceResponse>
    {
        public int HocVienId { get; set; }
        public string HoTen { get; set; }
        public string QuanHe { get; set; }
        public int Tuoi { get; set; }
        public string NgheNghiep { get; set; }
        public bool SongChung { get; set; }
    }
}
