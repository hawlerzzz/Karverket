using Microsoft.EntityFrameworkCore;
using Karverket.Models;


namespace Karverket.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet for å representere Product-tabellen i databasen
        //public DbSet<GeoChange> GeoChanges { get; set; }
        public DbSet<GeoChange> GeoChanges2 { get; set; }

        // Konfigurering av tilkobling til MariaDB-database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("Server=localhost;port=3306;uid=ahmed;pwd=123;database=KARTVERKET",
        //            new MySqlServerVersion(new Version(10, 4, 14)));  // Sett riktig MariaDB-versjon
        //    }
        //}

        // Eventuelle tilleggskonfigurasjoner for entitetene
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Konfigurerer modellen hvis nødvendig
        //    modelBuilder.Entity<User>()
        //        .Property(p => p.Name)
        //        .HasMaxLength(100)
        //        .IsRequired();
        //}
    }
}