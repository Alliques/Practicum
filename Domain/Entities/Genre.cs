﻿using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Genre
    {
        public Genre()
        {
            //BookGenres = new HashSet<BookGenre>();
        }

        public int Id { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<Book> Books { get; set; }
        //public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
