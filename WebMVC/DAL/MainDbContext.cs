using Microsoft.EntityFrameworkCore;
using WebMVC.DAL.Models;

namespace WebMVC.DAL
{
    public class MainDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<Phrases> Phrases { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Phrases>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
