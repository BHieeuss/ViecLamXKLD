using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Infrastructure.Configurations.HocVien
{
    public class QuaTrinhLamViecConfiguration : IEntityTypeConfiguration<QuaTrinhLamViec>
    {
        public void Configure(EntityTypeBuilder<QuaTrinhLamViec> builder)
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

            builder.Property(x => x.TenCongTy)
                .HasColumnName("TenCongTy")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.NoiDungCongViec)
                .HasColumnName("NoiDungCongViec")
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            builder.HasOne<ThongTinHocVien>()
                .WithMany()
                .HasForeignKey(x => x.HocVienId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.HocVien)
                .WithMany(hv => hv.QuaTrinhLamViecs)
                .HasForeignKey(x => x.HocVienId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("QuaTrinhLamViec");
        }
    }
}
