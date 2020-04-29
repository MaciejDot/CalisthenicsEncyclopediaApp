using ArticleService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArticleService.Data
{
    public class ArticleServiceContext : DbContext
    {
        public ArticleServiceContext(DbContextOptions<ArticleServiceContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.ToTable("Users", "Security");

                entity.HasKey(u => u.Id)
                    .HasName("PK_Users");

                entity.Property(u => u.Id)
                    .HasMaxLength(100);

                entity.HasMany(u => u.Articles)
                    .WithOne(a => a.Author)
                    .HasForeignKey(a => a.AuthorId)
                    .HasConstraintName("FK_Articles_Users")
                    .IsRequired();
            });

            modelBuilder.Entity<Thumbnail>(entity => {
                entity.ToTable("Thumbnails", "Article");

                entity.HasKey(t => t.Id)
                    .HasName("PK_Thumbnail");

                entity.Property(t => t.Content)
                    .HasMaxLength(250 * 1024)
                    .IsRequired();

                entity.HasMany(t => t.Article)
                    .WithOne(s => s.Thumbnail)
                    .HasForeignKey(s => s.ThumbnailId)
                    .HasConstraintName("FK_Articles_Thumbnails")
                    .IsRequired();
            });

            modelBuilder.Entity<Article>(entity => {
                entity.ToTable("Articles", "Article");

                entity.HasKey(t => t.Id)
                    .HasName("PK_Article");

                entity.Property(a => a.Content)
                    .HasMaxLength(8000);

                entity.Property(a => a.Description)
                    .HasMaxLength(1000);

                entity.Property(a => a.Title)
                    .HasMaxLength(300);

                entity.HasIndex(a => a.Title)
                    .HasName("IX_Article_Title")
                    .IsUnique();

                entity.HasIndex(a => a.Created)
                    .HasName("IX_Article_Created")
                    .IsUnique();
            });
        }
    }
}
