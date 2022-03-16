using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class ExportConfiguration : IEntityTypeConfiguration<Export>
    {
        public void Configure(EntityTypeBuilder<Export> builder)
        {
            builder.ToTable("Exports");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.No).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(x => x.Date).IsRequired().HasColumnType("datetime");

        }
    }
}
