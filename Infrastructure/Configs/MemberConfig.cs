using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            //Properties
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).HasDefaultValueSql("NEWID()");
            
            //Relationships
            builder.HasMany(m => m.Advertisements).WithOne(a => a.Member).HasForeignKey(a => a.MemberId);
            builder.HasMany(m => m.MemberLanguage).WithOne(mlg => mlg.Member).HasForeignKey(mlg => mlg.MemberId);
            builder.HasMany(m => m.MemberLocation).WithOne(ml => ml.Member).HasForeignKey(ml => ml.MemberId);
        }
    }
}
