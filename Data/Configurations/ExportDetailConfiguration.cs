using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class ExportDetailConfiguration : IEntityTypeConfiguration<ExportDetail>
    {
        public void Configure(EntityTypeBuilder<ExportDetail> builder)
        {
            builder.ToTable("ExportDetails");

            builder.HasKey(x => new { x.ExportId, x.ProductId });

            builder.Property(x => x.Quantity).IsRequired().HasColumnType("int");
            builder.Property(x => x.Note).HasColumnType("nvarchar").HasMaxLength(200);

        }
    }
}
