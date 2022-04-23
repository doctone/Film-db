namespace film_db.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string PhotoUrl { get; set; }
        public List<Film> Films { get; set; }
    }
}