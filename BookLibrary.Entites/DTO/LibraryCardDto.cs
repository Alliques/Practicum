using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Entites.DTO
{
    public class LibraryCardDto
    {
        [Required(ErrorMessage = "HumanId is a required field.")]
        public int HumanId { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTimeOffset Date { get; set; }
    }
}
