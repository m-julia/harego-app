using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class AdvertisementConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).HasDefaultValueSql("NEWID()");
            builder.Property(p => p.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
