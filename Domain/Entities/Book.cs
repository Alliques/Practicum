using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Book
    {
        public Book()
        {
           // LibraryCards = new HashSet<LibraryCard>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Person> Persons { get; set; }
        //public virtual ICollection<LibraryCard> LibraryCards { get; set; }
    }
}
