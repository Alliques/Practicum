using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
