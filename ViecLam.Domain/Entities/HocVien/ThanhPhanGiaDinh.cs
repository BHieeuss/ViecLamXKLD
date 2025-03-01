namespace ViecLam.Domain.Entities.HocViens
{
    public class ThanhPhanGiaDinh
    {
        public int Id { get; set; } 
        public int HocVienId { get; set; }
        public string HoTen { get; set; }
        public string QuanHe { get; set; }
        public int Tuoi { get; set; }
        public string NgheNghiep { get; set; }
        public bool SongChung { get; set; }

        public ThongTinHocVien HocVien { get; set; }
    }
}
