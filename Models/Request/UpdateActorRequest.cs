namespace film_db.Models
{
    public class UpdateActorRequest
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string PhotoUrl { get; set; }
    }
}