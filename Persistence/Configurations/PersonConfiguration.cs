using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasMany(c => c.Books)
                .WithMany(s => s.Persons)
                .UsingEntity<LibraryCard>(
                b => b.HasOne(b => b.Books)
                .WithMany()
                .HasForeignKey(x => x.BooksId)
                .HasConstraintName("FK_LibraryCards_BooksId"),
                p => p.HasOne(p => p.Persons)
                .WithMany()
                .HasForeignKey(x => x.PersonsId)
                .HasConstraintName("FK_LibraryCards_PersonsId"));
        }
    }
}
