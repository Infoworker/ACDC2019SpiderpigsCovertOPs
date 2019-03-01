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

        public DbSet<Person> Persons { get; set; }
        public DbSet<Sensordata> Sensordatas { get; set; }
    }
}