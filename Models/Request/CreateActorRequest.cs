namespace film_db.Models
{
    public class CreateActorRequest
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string PhotoUrl { get; set; }
    }
}