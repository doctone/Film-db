namespace film_db.Models
{
    public class UpdateDirectorRequest
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        
        public string PhotoUrl { get; set; }
    }
}