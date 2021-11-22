using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "GenreName is a required field.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "GenreName is a required field.")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
