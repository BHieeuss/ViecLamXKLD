using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViecLam.Domain.Entities;

namespace ViecLam.Infrastructure.Configurations
{
    public class HocVienConfig : IEntityTypeConfiguration<HocVien>
    {
        public void Configure(EntityTypeBuilder<HocVien> builder)
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

            builder.ToTable("HocVien");
        }
    }
}
