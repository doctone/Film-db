namespace film_db.Models
{
    public class CreateDirectorRequest
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
    }
}