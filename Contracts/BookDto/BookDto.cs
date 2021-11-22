using Domain.Entites;
using System.Collections.Generic;

namespace Contracts
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
