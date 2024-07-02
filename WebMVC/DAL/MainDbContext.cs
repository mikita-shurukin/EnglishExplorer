using Microsoft.EntityFrameworkCore;
using WebMVC.DAL.Models;

namespace WebMVC.DAL
{
    public class MainDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<GrammarTopic> GrammarTopics { get; set; }
        public DbSet<GrammarContent> GrammarContents { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestAnswer> TestAnswers { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GrammarTopic>()
                .HasMany(t => t.Contents)
                .WithOne(c => c.GrammarTopic)
                .HasForeignKey(c => c.GrammarTopicId);

            modelBuilder.Entity<GrammarTopic>()
                .HasMany(t => t.TestQuestions)
                .WithOne(q => q.GrammarTopic)
                .HasForeignKey(q => q.GrammarTopicId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
        