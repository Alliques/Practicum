using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public partial class RepositoryContext : DbContext
    {
       
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .HasColumnName("middle_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__book__author_id__662B2B3B");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__book_genr__book___6AEFE058");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__book_genr__genre__6BE40491");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<LibraryCard>(entity =>
            {
                entity.ToTable("library_card");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("receipt_date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.LibraryCards)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__library_c__book___6EC0713C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.LibraryCards)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__library_c__perso__6FB49575");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .HasColumnName("middle_name");
            });

           // OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
