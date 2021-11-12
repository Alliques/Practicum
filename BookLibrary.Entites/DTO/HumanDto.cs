using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Entites.DTO
{
    public class HumanDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Patronymic is a required field.")]
        public string Patronymic { get; set; }
    }
}
