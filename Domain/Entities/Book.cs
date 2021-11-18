using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Book
    {
        public Book()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
