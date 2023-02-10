using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Province>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Provinces)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Province)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country{ ID = 1, Name = "Country 1" },
                new Country{ ID = 2, Name = "Country 2" },
                new Country{ ID = 3, Name = "Country 3" },
            });

            modelBuilder.Entity<Province>().HasData(new Province[]
            {
                new Province { ID = 1, Name = "Province 1.1", CountryID = 1 },
                new Province { ID = 2, Name = "Province 2.1", CountryID = 2 },
                new Province { ID = 3, Name = "Province 2.2", CountryID = 2 },
                new Province { ID = 4, Name = "Province 2.3", CountryID = 2 },
                new Province { ID = 5, Name = "Province 3.1", CountryID = 3 },
                new Province { ID = 6, Name = "Province 3.2", CountryID = 3 },
            });
        }

#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
#endif
    }
}
