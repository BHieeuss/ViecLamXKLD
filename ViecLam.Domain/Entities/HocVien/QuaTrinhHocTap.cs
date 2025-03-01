namespace ViecLam.Domain.Entities.HocViens
{
    public class QuaTrinhHocTap
    {
        public int Id { get; set; }
        public int HocVienId { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganhDaoTao { get; set; }

        public ThongTinHocVien HocVien { get; set; }

    }
}
