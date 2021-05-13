using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class MemberLocationConfig : IEntityTypeConfiguration<MemberLocation>
    {
        public void Configure(EntityTypeBuilder<MemberLocation> builder)
        {
            builder.HasKey(x => new { x.MemberId, x.LocationId });
        }
    }
}
