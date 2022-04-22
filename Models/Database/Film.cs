namespace film_db.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Director? Director { get; set; }
        public int DirectorId { get; set; }
        public DateTime Year { get; set; }
        public string ImageUrl { get; set; }
    }
}