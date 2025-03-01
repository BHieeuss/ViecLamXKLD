namespace ViecLam.Domain.Entities.HocViens
{
    public class ThongTinHocVien
    {
        public int Id { get; set; }
        public int SoCMND { get; set; }
        public int TinhTrangHonNhan { get; set; }
        public int SoDienThoaiTTS { get; set; }
        public int SoDienThoaiNguoiThan { get; set; }
        public int SoDienThoaiCBTD { get; set; }
        public int ThuanTay { get; set; }
        public int NhomMau { get; set; }
        public double ChieuCao { get; set; }
        public double CanNang { get; set; }

        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string ThiLucMat { get; set; }
        public string MuMau { get; set; }
        public string TonGiao { get; set; }
        public string DiemManh { get; set; }
        public string DiemYeu { get; set; }
        public string SoThich { get; set; }
        public string TuNhanXet { get; set; }
        public string ChuyenMonDaoTao { get; set; }
        public string ThuNhapBanThan { get; set; }
        public string ThuNhapGiaDinh { get; set; }
        public string LyDoDiNhat { get; set; }
        public string SoTienSau3Nam { get; set; }
        public string DuDinhSauKhiKetThucHopDong { get; set; }

        public bool ChanTayDiTat { get; set; }
        public bool DaPhauThuat { get; set; }
        public bool CoHinhXam { get; set; }
        public bool UongBiaRuou { get; set; }
        public bool HutThuoc { get; set; }
        public bool TienSuBenhLyGiaDinh { get; set; }
        public bool KinhNghiemSongTapThe { get; set; }
        public bool BietNauAn { get; set; }
        public bool DaTungRaNuocNgoai { get; set; }
        public bool DaLamThuTucVisaNhat { get; set; }

        public DateTime NgayThangNamSinh { get; set; }
        public DateTime NgayCapCMND { get; set; }

        public ICollection<QuaTrinhHocTap> QuaTrinhHocTaps { get; set; }
        public ICollection<QuaTrinhLamViec> QuaTrinhLamViecs { get; set; }
        public ICollection<ThanhPhanGiaDinh> ThanhPhanGiaDinhs { get; set; }
    }
}
