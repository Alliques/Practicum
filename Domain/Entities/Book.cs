using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Book
    {
        public Book()
        {
            BookGenres = new HashSet<BookGenre>();
            LibraryCards = new HashSet<LibraryCard>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }
    }
}
