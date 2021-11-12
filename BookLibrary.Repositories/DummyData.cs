using BookLibrary.Entites.Models;
using System.Collections.Generic;

namespace BookLibrary.Repositories
{
    public static class DummyData
    {
        /// <summary>
        /// 2.1.3 - Dummy data for the library cards entries
        /// </summary>
        public static readonly IEnumerable<LibraryCard> libraryCards = new List<LibraryCard>();

        /// <summary>
        /// 1.2.3 - Dummy data represents the book collection
        /// </summary>
        public static readonly IEnumerable<Book> bookList = new List<Book>
        {
            new Book
            {
                Id = 2,
                AuthorId = 1,
                Genre = "Роман",Title = "Some novel"
            },
            new Book
            {
                Id = 1,
                AuthorId = 3,
                Genre = "Повесть",Title = "Затишье"
            },
            new Book
            {
                Id = 3,// new Guid("85fa7199-e8f2-4aab-a81b-14906174020a"),
                Genre = "Роман",
                AuthorId = 1,
                Title = "Одисея капитана Блада"
            }
        };


        /// <summary>
        /// 1.2.3 - Dummy data represents the human collection
        /// </summary>
        public static readonly IEnumerable<Human> humanList = new List<Human>
        {
            new Human
            {
                Id = 3, //new Guid("cc66e001-80b8-4623-ae52-4929decfbed0"),
                Name ="Иван",
                Surname ="Тургенев",
                Patronymic ="Сергеевич"
            },
            new Human
            {
                Id = 1, //new Guid("31a46390-12b6-4f78-b505-52a8b2ed4865"),
                Name ="Наталья",
                Surname ="Шпак",
                Patronymic ="Алексеевна"
            },
            new Human
            {
                Id = 2, //new Guid("81830a02-2b6f-49d9-9402-01a1efcd3e20"),
                Name ="Кирилл",
                Surname ="Иванов",
                Patronymic ="Борисович"
            }
        };
    }
}
