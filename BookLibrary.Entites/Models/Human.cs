namespace BookLibrary.Entites.Models
{
    /// <summary>
    /// 1.2.1 - An Ooject represents the user
    /// </summary>
    public class Human : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
