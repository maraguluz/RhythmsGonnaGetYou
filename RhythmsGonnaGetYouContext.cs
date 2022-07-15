using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace RhythmsGonnaGetYou
{
    public class RhythmsGonnaGetYouContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou");
        }
        public Band FindOneBand(string nameToFind)
        {
            Band foundBand = Bands.FirstOrDefault(Employee => Employee.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundBand;
        }
    }
}