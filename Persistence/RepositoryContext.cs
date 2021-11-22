using Domain.Entites;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(c => c.Books)
                .WithMany(s => s.Persons)
                .UsingEntity<LibraryCard>(
                b=>b.HasOne(b=>b.Books)
                .WithMany()
                .HasForeignKey(x=>x.BooksId)
                .HasConstraintName("FK_LibraryCards_BooksId"),
                p => p.HasOne(p => p.Persons)
                .WithMany()
                .HasForeignKey(x => x.PersonsId)
                .HasConstraintName("FK_LibraryCards_PersonsId"));

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName)
                .HasMaxLength(20);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Authors_AuthorId");
            });
        }
    }
}
