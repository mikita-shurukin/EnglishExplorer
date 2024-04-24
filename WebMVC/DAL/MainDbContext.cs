using Microsoft.EntityFrameworkCore;
using WebMVC.DAL.Models;

namespace WebMVC.DAL
{
    public class MainDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Здесь можно добавить настройки модели Word, если это необходимо

            // Например, если хотите настроить свойства колонок или связи, используйте fluent API:
            modelBuilder.Entity<Word>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
