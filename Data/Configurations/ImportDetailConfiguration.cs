using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class ImportDetailConfiguration : IEntityTypeConfiguration<ImportDetail>
    {
        public void Configure(EntityTypeBuilder<ImportDetail> builder)
        {
            builder.ToTable("ImportDetails");

            builder.HasKey(x => new { x.ImportId,x.ProductId });

            builder.Property(x => x.Quantity).IsRequired().HasColumnType("int");
            builder.Property(x => x.Note).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

        }
    }
}
