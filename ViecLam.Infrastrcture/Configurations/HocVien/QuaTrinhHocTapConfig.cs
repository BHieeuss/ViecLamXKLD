using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Infrastructure.Configurations.HocVien
{
    public class QuaTrinhHocTapConfiguration : IEntityTypeConfiguration<QuaTrinhHocTap>
    {
        public void Configure(EntityTypeBuilder<QuaTrinhHocTap> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.HocVienId)
                .HasColumnName("HocVienId")
                .IsRequired();

            builder.Property(x => x.TuNgay)
                .HasColumnName("TuNgay")
                .IsRequired();

            builder.Property(x => x.DenNgay)
                .HasColumnName("DenNgay")
                .IsRequired();

            builder.Property(x => x.TenTruong)
                .HasColumnName("TenTruong")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ChuyenNganhDaoTao)
                .HasColumnName("ChuyenNganhDaoTao")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(x => x.HocVien)
            .WithMany(hv => hv.QuaTrinhHocTaps)
            .HasForeignKey(x => x.HocVienId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("QuaTrinhHocTap");
        }
    }
}
