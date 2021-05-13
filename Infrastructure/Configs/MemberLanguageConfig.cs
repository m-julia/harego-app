using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class MemberLanguageConfig : IEntityTypeConfiguration<MemberLanguage>
    {
        public void Configure(EntityTypeBuilder<MemberLanguage> builder)
        {
            builder.HasKey(x => new { x.LanguageId, x.MemberId });
        }
    }
}
