using Felix.WebService.Data.Models;
using Felix.WebService.Data.Models.Comment;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.Data.Models.Movie;
using Microsoft.EntityFrameworkCore;

namespace Felix.WebService.Data
{
    public class FelixDbContext : DbContext
    {
        public FelixDbContext(DbContextOptions<FelixDbContext> options) : base(options)
        {
        }

        #region Tables
        public DbSet<User> User { get; set; }
        public DbSet<Seed> Seed { get; set; }
        public DbSet<Cut> Cut { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Shot> Shot { get; set; }
        public DbSet<ShotCutRel> ShotCutRel { get; set; }
        public DbSet<Comment> Comment { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasIndex(x => x.CodeName)
                .IsUnique();
            
            modelBuilder.Entity<Shot>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
