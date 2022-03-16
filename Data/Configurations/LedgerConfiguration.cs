using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class LedgerConfiguration : IEntityTypeConfiguration<Ledger>
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {
            builder.ToTable("Ledgers");

            builder.HasKey(x => x.Period);

            builder.Property(x => x.Period).IsRequired().HasColumnType("nvarchar").HasMaxLength(10);
            builder.Property(x => x.CloseDate).HasColumnType("datetime");
            builder.Property(x=>x.IsClosed).HasDefaultValue(false);

        }
    }
}
