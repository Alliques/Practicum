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
        //public virtual DbSet<BookGenre> BookGenre { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        //public virtual DbSet<LibraryCard> LibraryCard { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Author>(entity =>
        //    {
        //        entity.ToTable("Author");

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasMaxLength(20);

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasMaxLength(20);

        //        entity.Property(e => e.MiddleName).HasMaxLength(20);
        //    });

        //    modelBuilder.Entity<Book>(entity =>
        //    {
        //        entity.ToTable("Book");

        //        entity.Property(e => e.Title)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.HasOne(d => d.Author)
        //            .WithMany(p => p.Books)
        //            .HasForeignKey(d => d.AuthorId)
        //            .HasConstraintName("FK_Author_AuthorId");
        //    });

        //    modelBuilder.Entity<BookGenre>(entity =>
        //    {
        //        entity.HasKey(e => new { e.BookId, e.GenreId });

        //        entity.ToTable("BookGenre");

        //        entity.HasOne(d => d.Book)
        //            .WithMany(p => p.BookGenres)
        //            .HasForeignKey(d => d.BookId)
        //            .HasConstraintName("FK_BookGenre_BookId");

        //        entity.HasOne(d => d.Genre)
        //            .WithMany(p => p.BookGenres)
        //            .HasForeignKey(d => d.GenreId)
        //            .HasConstraintName("FK_BookGenre_GenreId");
        //    });

        //    modelBuilder.Entity<Genre>(entity =>
        //    {
        //        entity.ToTable("Genre");

        //        entity.Property(e => e.GenreName)
        //            .IsRequired()
        //            .HasMaxLength(20);
        //    });

        //    modelBuilder.Entity<LibraryCard>(entity =>
        //    {
        //        entity.ToTable("LibraryCard");

        //        entity.Property(e => e.ReceiptDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.Book)
        //            .WithMany(p => p.LibraryCards)
        //            .HasForeignKey(d => d.BookId)
        //            .HasConstraintName("FK__LibraryCa__BookI__4924D839");

        //        entity.HasOne(d => d.Person)
        //            .WithMany(p => p.LibraryCards)
        //            .HasForeignKey(d => d.PersonId)
        //            .HasConstraintName("FK__LibraryCa__Perso__4A18FC72");
        //    });

        //    modelBuilder.Entity<Person>(entity =>
        //    {
        //        entity.ToTable("Person");

        //        entity.Property(e => e.BirthDate).HasColumnType("date");

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasMaxLength(20);

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasMaxLength(20);

        //        entity.Property(e => e.MiddleName).HasMaxLength(20);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
