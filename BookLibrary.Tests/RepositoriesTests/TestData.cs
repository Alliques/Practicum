using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace BookLibrary.Tests
{
    public class TestData
    {
        private static readonly Lazy<TestData> _testData = new Lazy<TestData>(() => new TestData());
        public readonly DbContextOptions<RepositoryContext> options;

        public TestData()
        {
            options = new DbContextOptionsBuilder<RepositoryContext>()
            .UseInMemoryDatabase(databaseName: "BookLibraryTest")
            .Options;
            CreateDummyData(options);
        }
        public static TestData GetInstance()
        {
            return _testData.Value;
        }

        public void CreateDummyData(DbContextOptions<RepositoryContext> options)
        {
            using (var context = new RepositoryContext(options))
            {
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
                        Title = "Постоялый двор",
                        AuthorId = 1
                    },
                    new Book
                    {
                        Title = "Затишье",
                        AuthorId = 1
                    },
                    new Book
                    {
                        Title = "Одисея капитана Блада",
                        AuthorId = 3
                    },
                    new Book
                    {
                        Title = "Собрание сочинений",
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "Пустые земли",
                        AuthorId = 4
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
                        Id=15,
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
                context.SaveChangesAsync();
            }
        }
    }
}
