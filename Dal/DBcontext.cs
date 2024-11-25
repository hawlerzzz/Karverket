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
        public DbSet<AreaChange> Innmeldinger { get; set; }
        public DbSet<Innmelding> INynnmeldinger { get; set; }

        public DbSet<Innmelding> Innmeldinger1 { get; set; }


        // DbSet for å represntere Users-tabellen som inkludere user objekter i databasen
        public DbSet<User> Users { get; set; }

       
    }
}