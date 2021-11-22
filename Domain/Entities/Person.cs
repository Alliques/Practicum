using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Person: BaseEntity
    {
        public Person()
        {
        }

        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Book> Books { get; set; }
    }
}
