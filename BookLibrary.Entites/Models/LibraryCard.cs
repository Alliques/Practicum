using System;

namespace BookLibrary.Entites.Models
{
    /// <summary>
    /// 2.1.1 - Object represents a new entry in the library card
    /// </summary>
    public class LibraryCard : BaseModel
    {
        public int HumanId { get; set; }
        public Human Human { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
