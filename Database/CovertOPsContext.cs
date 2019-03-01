using ACDC2019SpiderpigsCovertOPs.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ACDC2019SpiderpigsCovertOPs.Database
{
#pragma warning disable 1591

    public class CovertOPsContext : DbContext
    {
        public CovertOPsContext(DbContextOptions<CovertOPsContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Sensordata> Sensordatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(s => s.Location).WithOne(s => s.Person).IsRequired();
        }
    }
}