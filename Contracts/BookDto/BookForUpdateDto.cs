using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class BookForUpdateDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is a required field.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Genre is a required field.")]
        public List<int> GenreIds { get; set; }
        public DateTime WriteDate { get; set; }
    }
}
