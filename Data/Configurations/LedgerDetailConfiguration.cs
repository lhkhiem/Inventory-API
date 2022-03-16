using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class LedgerDetailConfiguration : IEntityTypeConfiguration<LedgerDetail>
    {
        public void Configure(EntityTypeBuilder<LedgerDetail> builder)
        {
            builder.ToTable("LedgerDetails");

            builder.HasKey(x => new { x.LedgerId, x.ProductId });

            builder.Property(x => x.Opening).IsRequired().HasColumnType("int");
            builder.Property(x => x.Ending).IsRequired().HasColumnType("int");

        }
    }
}
