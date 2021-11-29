using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class AuthorBookForCreationDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is a required field.")]

        public List<GenreDto> Genres { get; set; }
    }
}
