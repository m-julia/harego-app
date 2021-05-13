using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).HasDefaultValueSql("NEWID()");

            builder.HasMany(l => l.MemberLocation).WithOne(ml => ml.Location).HasForeignKey(ml => ml.LocationId);
        }
    }
}
