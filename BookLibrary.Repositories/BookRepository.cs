using BookLibrary.Contracts;
using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// 1.2.3 - Dummy objects representings humans
        /// </summary>
        private readonly List<Book> _bookList;

        public BookRepository()
        {
            _bookList = new List<Book>
            {
                new Book
                {
                    Id = 2,//new Guid("743badbb-9b8b-42f0-a3c9-0b3c7e0391db"),
                    Author = "Шпак Наталья Алексеевна",
                    Genre = "Роман",
                    Title = "Some novel"
                },
                new Book
                {
                    Id = 1,//new Guid("44f5f217-6787-4951-bf5a-b7d01554e578"),
                    Author = "Тургенев Иван Сергеевич",
                    Genre = "Повесть",
                    Title = "Затишье"
                },
                new Book
                {
                    Id = 3,// new Guid("85fa7199-e8f2-4aab-a81b-14906174020a"),
                    Genre = "Роман",
                    Author = "Рафаэль Саббатини",
                    Title = "Одисея капитана Блада"
                }
            };
        }

        public void Create(Book entity)
        {
            _bookList.Add(entity);
        }

        public void Delete(Book entity)
        {
            _bookList.Remove(entity);
        }

        public IEnumerable<Book> FindAll()
        {
            return _bookList;
        }

        public IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            return _bookList.Where(expression.Compile()).AsQueryable();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
