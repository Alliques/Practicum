namespace Contracts
{
    public class BookParameters
    {
        public int? FilteringById { get; set; } = null;

        public string OrderingBy { get; set; }
        public string AuthName { get; set; }
        public string AuthSurname { get; set; }
        public string AuthPatronymic { get; set; }
        public string Genre { get; set; }
    }
}
