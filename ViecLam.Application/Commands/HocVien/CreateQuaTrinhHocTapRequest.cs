using MediatR;
using ViecLam.Application.Response;

namespace ViecLam.Application.Commands.HocVien
{
    public class CreateQuaTrinhHocTapRequest : IRequest<ServiceResponse>
    {
        public int HocVienId { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganhDaoTao { get; set; }
    }
}
