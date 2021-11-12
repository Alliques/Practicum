namespace BookLibrary.RequestOptions
{
    public class BookParameters
    {
        public int? FilteringById { get; set; } = null;

        public string OrderingBy { get; set; }
    }
}
