
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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<AboutMain> AboutMain { get; set; }

        public DbSet<AboutIcon> AboutIcon { get; set; }

        public DbSet<ExspertTitle> ExspertTitle { get; set; }

        public DbSet<Exsperts> Exsperts { get; set; }

        public DbSet<BlogTitle> BlogTitle { get; set; }

        public DbSet<BlogMain> Blogs { get; set; }

        public DbSet<Say> Says { get; set; }

        public DbSet<Settings> Settings { get; set; }
    }
}
