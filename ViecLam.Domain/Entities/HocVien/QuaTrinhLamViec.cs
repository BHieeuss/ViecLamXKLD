namespace ViecLam.Domain.Entities.HocViens
{
    public class QuaTrinhLamViec
    {
        public int Id { get; set; }
        public int HocVienId { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TenCongTy { get; set; }
        public string NoiDungCongViec { get; set; }

        public ThongTinHocVien HocVien { get; set; }
    }
}
