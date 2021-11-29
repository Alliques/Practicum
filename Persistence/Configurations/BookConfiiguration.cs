using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BookConfiiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasOne(d => d.Author)
                            .WithMany(p => p.Books)
                            .HasForeignKey(d => d.AuthorId)
                            .HasConstraintName("FK_Authors_AuthorId");
        }
    }
}
