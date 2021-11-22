using System.Collections.Generic;

namespace Contracts
{
    public class BookWithoutAuthorDto
    {
        public string Title { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
