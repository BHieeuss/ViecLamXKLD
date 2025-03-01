using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Infrastructure.Configurations.HocVien
{
    public class ThongTinHocVienConfig : IEntityTypeConfiguration<ThongTinHocVien>
    {
        public void Configure(EntityTypeBuilder<ThongTinHocVien> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.HoTen)
                .HasColumnName("HoTen")
                .IsRequired();

            builder.Property(x => x.NgayThangNamSinh)
                .HasColumnName("NgayThangNamSinh")
                .IsRequired();

            builder.Property(x => x.DiaChi)
                .HasColumnName("DiaChi")
                .IsRequired();

            builder.Property(x => x.SoCMND)
                .HasColumnName("SoCMND")
                .IsRequired();

            builder.Property(x => x.NgayCapCMND)
                .HasColumnName("NgayCapCMND")
                .IsRequired();

            builder.Property(x => x.TinhTrangHonNhan)
                .HasColumnName("TinhTrangHonNhan")
                .IsRequired();

            builder.Property(x => x.SoDienThoaiTTS)
                .HasColumnName("SoDienThoaiTTS")
                .IsRequired();

            builder.Property(x => x.SoDienThoaiNguoiThan)
                .HasColumnName("SoDienThoaiNguoiThan")
                .IsRequired();

            builder.Property(x => x.SoDienThoaiCBTD)
                .HasColumnName("SoDienThoaiCBTD")
                .IsRequired();

            builder.Property(x => x.ThiLucMat)
                .HasColumnName("ThiLucMat")
                .IsRequired();

            builder.Property(x => x.MuMau)
                .HasColumnName("MuMau")
                .IsRequired();

            builder.Property(x => x.ThuanTay)
                .HasColumnName("ThuanTay")
                .IsRequired();

            builder.Property(x => x.NhomMau)
                .HasColumnName("NhomMau")
                .IsRequired();

            builder.Property(x => x.ChieuCao)
                .HasColumnName("ChieuCao")
                .IsRequired();

            builder.Property(x => x.CanNang)
                .HasColumnName("CanNang")
                .IsRequired();

            builder.Property(x => x.TonGiao)
                .HasColumnName("TonGiao");

            builder.Property(x => x.DiemManh)
                .HasColumnName("DiemManh");

            builder.Property(x => x.DiemYeu)
                .HasColumnName("DiemYeu");

            builder.Property(x => x.SoThich)
                .HasColumnName("SoThich");

            builder.Property(x => x.TuNhanXet)
                .HasColumnName("TuNhanXet");

            builder.Property(x => x.ChuyenMonDaoTao)
                .HasColumnName("ChuyenMonDaoTao");

            builder.Property(x => x.ThuNhapBanThan)
                .HasColumnName("ThuNhapBanThan");

            builder.Property(x => x.ThuNhapGiaDinh)
                .HasColumnName("ThuNhapGiaDinh");

            builder.Property(x => x.LyDoDiNhat)
                .HasColumnName("LyDoDiNhat");

            builder.Property(x => x.SoTienSau3Nam)
                .HasColumnName("SoTienSau3Nam");

            builder.Property(x => x.DuDinhSauKhiKetThucHopDong)
                .HasColumnName("DuDinhSauKhiKetThucHopDong");

            builder.Property(x => x.ChanTayDiTat)
                .HasColumnName("ChanTayDiTat")
                .IsRequired();

            builder.Property(x => x.DaPhauThuat)
                .HasColumnName("DaPhauThuat")
                .IsRequired();

            builder.Property(x => x.CoHinhXam)
                .HasColumnName("CoHinhXam")
                .IsRequired();

            builder.Property(x => x.UongBiaRuou)
                .HasColumnName("UongBiaRuou")
                .IsRequired();

            builder.Property(x => x.HutThuoc)
                .HasColumnName("HutThuoc")
                .IsRequired();

            builder.Property(x => x.TienSuBenhLyGiaDinh)
                .HasColumnName("TienSuBenhLyGiaDinh")
                .IsRequired();

            builder.Property(x => x.KinhNghiemSongTapThe)
                .HasColumnName("KinhNghiemSongTapThe")
                .IsRequired();

            builder.Property(x => x.BietNauAn)
                .HasColumnName("BietNauAn")
                .IsRequired();

            builder.Property(x => x.DaTungRaNuocNgoai)
                .HasColumnName("DaTungRaNuocNgoai")
                .IsRequired();

            builder.Property(x => x.DaLamThuTucVisaNhat)
                .HasColumnName("DaLamThuTucVisaNhat")
                .IsRequired();

            builder.ToTable("ThongTinHocVien");
        }
    }
}
