using Domain.Entites;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime WriteDate { get; set; }
        public AuthorDto Author { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
