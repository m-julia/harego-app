using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).HasDefaultValueSql("NEWID()");

            builder.HasOne(m => m.Creator).WithMany(r => r.CreatedReviews).HasForeignKey(r => r.CreatorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Recipient).WithMany(r => r.ReceivedReviews).HasForeignKey(r => r.RecipientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
