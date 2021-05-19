using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksEntities
{
    public partial class AzurebooksContext : DbContext
    {
        public AzurebooksContext()
        {
        }

        public AzurebooksContext(DbContextOptions<AzurebooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorOfBook> AuthorsOfBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AzureBooks;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDay).HasColumnType("datetime2(0)");

                entity.Property(e => e.Email)
                    .HasColumnType("Email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AuthorOfBook>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsOfBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_AuthorsOfBooks_To_Authors");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorsOfBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_AuthorsOfBooks_To_Books");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateReleased).HasColumnType("datetime2(0)");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(13);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
