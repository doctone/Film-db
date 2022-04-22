namespace film_db.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
    }
}