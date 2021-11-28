using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Author: BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
