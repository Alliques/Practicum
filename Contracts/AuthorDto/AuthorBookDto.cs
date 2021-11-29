using System.Collections.Generic;

namespace Contracts
{
    public class AuthorBookDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public IEnumerable<BookWithoutAuthorDto> Books { get; set; }
    }
}
