using System;
using System.Collections.Generic;

namespace Contracts
{
    public class BookWithoutAuthorDto
    {
        public string Title { get; set; }
        public DateTime WriteDate { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
