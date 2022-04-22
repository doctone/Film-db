namespace film_db.Models
{
    public class ExtendedDirectorResponse
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public List<Film> Films { get; set; }
    }
}