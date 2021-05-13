using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).HasDefaultValueSql("NEWID()");

            builder.HasMany(l => l.MemberLanguage).WithOne(ml => ml.Language).HasForeignKey(ml => ml.LanguageId);
        }
    }
}
