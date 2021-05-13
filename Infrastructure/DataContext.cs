using Data;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MemberLanguage> MemberLanguages { get; set; }
        public DbSet<MemberLocation> MemberLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configs
            modelBuilder.ApplyConfiguration(new MemberConfig());
            modelBuilder.ApplyConfiguration(new AdvertisementConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new MemberLanguageConfig());
            modelBuilder.ApplyConfiguration(new MemberLocationConfig());
        }
    }
}
