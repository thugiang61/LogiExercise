using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace QuizApi.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<QuizItem>(
        //            eb =>
        //            {
        //                eb.HasNoKey();
        //            });
        //}

        public DbSet<QuizItem> QuizItems { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
    }
}