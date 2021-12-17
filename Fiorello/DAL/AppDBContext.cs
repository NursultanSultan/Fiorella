
using Fiorello.Models;
using Microsoft.EntityFrameworkCore;


namespace Fiorello.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Sliderintro> Sliderintro { get; set; }
    }
}
