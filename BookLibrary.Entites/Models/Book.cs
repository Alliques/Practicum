namespace BookLibrary.Entites.Models
{
    /// <summary>
    /// 1.2.2 An object represents the book
    /// </summary>
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
