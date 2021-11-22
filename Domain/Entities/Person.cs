using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Person
    {
        public Person()
        {
            //LibraryCards = new HashSet<LibraryCard>();
        }

        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Book> Books { get; set; }

        //public virtual ICollection<LibraryCard> LibraryCards { get; set; }
    }
}
