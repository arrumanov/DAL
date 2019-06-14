using Garden.Core.DAL;
using Garden.Core.Entities;
using Garden.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Garden.DAL
{
    public class StorageContext : DbContext, IStorageContext
    {
        private string connectionString;

        public DbSet<Article> Articles { get; set; }
        public DbSet<Article> Comments { get; set; }

        public StorageContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Article>(new MapArticle().Configure);
            modelBuilder.Entity<Comment>(new MapComment().Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
