using MediatR;
using ViecLam.Application.Response;

namespace ViecLam.Application.Commands.HocVien
{
    public class CreateQuaTrinhLamViecRequest : IRequest<ServiceResponse>
    {
        public int HocVienId { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TenCongTy { get; set; }
        public string NoiDungCongViec { get; set; }
    }
}
