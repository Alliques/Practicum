﻿using BookLibrary.Tests.Common;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace BookLibrary.Tests
{
    public class ContextFactory 
    {
        public static RepositoryContext Create()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new RepositoryContext(options);
            context.Database.EnsureCreated();

            #region Author
            context.Authors.AddRange(
                new Author
                {
                    FirstName = "Иван",
                    LastName = "Тургенев",
                    MiddleName = "Сергеевич",
                },
                new Author
                {
                    FirstName = "Михаил",
                    LastName = "Лермонтов",
                    MiddleName = "Юрьевич",
                },
                new Author
                {
                    FirstName = "Рафаэль",
                    LastName = "Саббатини",
                    MiddleName = null,
                },
                new Author
                {
                    FirstName = "Джек",
                    LastName = "Лондон",
                    MiddleName = null,
                },
                new Author
                {
                    FirstName = "Алексей",
                    LastName = "Калугин",
                    MiddleName = "Александрович",
                },
                new Author
                {
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                });
            #endregion

            #region Genres
            context.Genres.AddRange(
                new Genre { GenreName = "Роман" },
                new Genre { GenreName = "Поэзия" },
                new Genre { GenreName = "Рассказ" },
                new Genre { GenreName = "Повесть" });
            #endregion

            #region Books
            context.Books.AddRange(
                new Book
                {
                    WriteDate=new DateTime(1992,1,1),
                    Title = "Постоялый двор",
                    AuthorId = 1
                },
                new Book
                {
                    WriteDate = new DateTime(1992, 1, 1),
                    Title = "Затишье",
                    AuthorId = 1
                },
                new Book
                {
                    WriteDate = new DateTime(1934, 1, 1),
                    Title = "Одисея капитана Блада",
                    AuthorId = 3
                },
                new Book
                {
                    WriteDate = new DateTime(1982, 1, 1),
                    Title = "Собрание сочинений",
                    AuthorId = 2
                },
                new Book
                {
                    WriteDate = new DateTime(1992, 1, 1),
                    Title = "Пустые земли",
                    AuthorId = 4
                },
                new Book
                {
                    WriteDate = new DateTime(1992, 1, 1),
                    Title = "Test",
                    AuthorId = 4
                },
                new Book
                {
                    WriteDate = new DateTime(1992, 1, 1),
                    Title = "Test2",
                    AuthorId = 1
                });
            #endregion

            #region Persons
            context.Persons.AddRange(
                new Person
                {
                    BirthDate = System.DateTime.Now,
                    FirstName = "Виктория",
                    MiddleName = "Юрьевна",
                    LastName = "Шпак"
                },
                new Person
                {
                    BirthDate = System.DateTime.Now,
                    FirstName = "Кирилл",
                    MiddleName = "Борисович",
                    LastName = "Иванов"
                },
                new Person
                {
                    BirthDate = System.DateTime.Now,
                    FirstName = "Дмитрий",
                    MiddleName = "Валерьевич",
                    LastName = "Лопатин"
                },
                new Person
                {
                    Id = 15,
                    BirthDate = System.DateTime.Now,
                    FirstName = "FN_NotWriter",
                    MiddleName = "MN_NotWriter",
                    LastName = "LN_NotWrite"
                },
                new Person
                {
                    Id = 16,
                    BirthDate = System.DateTime.Now,
                    FirstName = "FN_NotWriter",
                    MiddleName = "MN_NotWriter",
                    LastName = "LN_NotWrite"
                });
            #endregion

            #region BookGenre
            context.BookGenres.AddRange(
                new BookGenre { BooksId = 1, GenresId = 4 },
                new BookGenre { BooksId = 1, GenresId = 4 },
                new BookGenre { BooksId = 4, GenresId = 1 },
                new BookGenre { BooksId = 4, GenresId = 3 },
                new BookGenre { BooksId = 1, GenresId = 1 },
                new BookGenre { BooksId = 1, GenresId = 3 },
                new BookGenre { BooksId = 2, GenresId = 1 },
                new BookGenre { BooksId = 3, GenresId = 2 },
                new BookGenre { BooksId = 5, GenresId = 3 },
                new BookGenre { BooksId = 5, GenresId = 4 },
                new BookGenre { BooksId = 6, GenresId = 1 });
            #endregion

            #region LibraryCard
            context.LibraryCards.AddRange(
                new LibraryCard { BooksId = 1, PersonsId = 1 },
                new LibraryCard { BooksId = 1, PersonsId = 3 },
                new LibraryCard { BooksId = 2, PersonsId = 3 },
                new LibraryCard { BooksId = 2, PersonsId = 1 },
                new LibraryCard { BooksId = 2, PersonsId = 2 },
                new LibraryCard { BooksId = 5, PersonsId = 3 },
                new LibraryCard { BooksId = 6, PersonsId = 3 });
            #endregion

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RepositoryContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
