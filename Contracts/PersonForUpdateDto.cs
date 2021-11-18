using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class PersonForUpdateDto
    {
        [Required(ErrorMessage = "FirstName is a required field.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a required field.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "MiddleName is a required field.")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "BirthDate is a required field.")]
        public DateTime BirthDate { get; set; }
    }
}
