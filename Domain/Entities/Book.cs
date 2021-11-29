using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Book: BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime WriteDate { get; set; }

        public Author Author { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Person> Persons { get; set; }
    }
}
