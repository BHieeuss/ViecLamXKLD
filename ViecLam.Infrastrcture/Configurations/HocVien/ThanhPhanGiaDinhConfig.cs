using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViecLam.Domain.Entities.HocViens;

namespace ViecLam.Infrastructure.Configurations.HocVien
{
    public class ThanhPhanGiaDinhConfiguration : IEntityTypeConfiguration<ThanhPhanGiaDinh>
    {
        public void Configure(EntityTypeBuilder<ThanhPhanGiaDinh> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.HocVienId)
                .HasColumnName("HocVienId")
                .IsRequired();

            builder.Property(x => x.HoTen)
                .HasColumnName("HoTen")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.QuanHe)
                .HasColumnName("QuanHe")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Tuoi)
                .HasColumnName("Tuoi")
                .IsRequired();

            builder.Property(x => x.NgheNghiep)
                .HasColumnName("NgheNghiep")
                .HasMaxLength(100);

            builder.Property(x => x.SongChung)
                .HasColumnName("SongChung")
                .IsRequired();

            builder.HasOne(x => x.HocVien)
                .WithMany(hv => hv.ThanhPhanGiaDinhs)
                .HasForeignKey(x => x.HocVienId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ThanhPhanGiaDinh");
        }
    }
}
