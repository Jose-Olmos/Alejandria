using Microsoft.EntityFrameworkCore;
using Alejandria.WebAPI.Implementation.Data.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Alejandria.WebAPI.Implementation.Data.Database
{
    public partial class AlejandriaContext : DbContext
    {
        public AlejandriaContext()
        {
        }

        public AlejandriaContext(DbContextOptions<AlejandriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<AuthorBook> AuthorBook { get; set; }
        public virtual DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("character varying");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.HasKey(e => new { e.Author, e.Book })
                    .HasName("author_books_pk");

                entity.ToTable("author-book");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Book).HasColumnName("book");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish-date")
                    .HasColumnType("date");

                entity.Property(e => e.ValidityDate)
                    .HasColumnName("validity-date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AuthorBook)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("author_books_fk_1");

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.AuthorBook)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("author_books_fk");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasIndex(e => e.Title)
                    .HasName("books_title_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary")
                    .HasColumnType("character varying");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
