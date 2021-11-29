
using System.Collections.Generic;

namespace Contracts
{
    public class AuthorForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<AuthorBookForCreationDto> Books { get; set; }
    }
}
