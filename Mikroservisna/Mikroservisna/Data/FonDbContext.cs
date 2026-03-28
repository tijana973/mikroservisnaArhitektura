using Microsoft.EntityFrameworkCore;
using Mikroservisna.Domain;

namespace Mikroservisna.Data
{
    public class FonDbContext : DbContext
    {
        public FonDbContext(DbContextOptions options)
            : base(options)
        {

        }   

        protected FonDbContext()
        {

        }
        public DbSet<Dogadjaj> Dogadjaji { get; set;}
        public DbSet<Predavac> Predavaci { get; set;}
        public DbSet<Lokacija> Lokacije { get; set; }
        }
}
