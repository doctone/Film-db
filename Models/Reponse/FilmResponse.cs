namespace film_db.Models
{
    public class FilmResponse
    {
        private readonly Film _film;

        public FilmResponse(Film Film)
        {
            _film = Film;
        }
        public int Id => _film.Id;
        public string? Title => _film.Title;
        public int DirectorId => _film.DirectorId;
        public DateTime year => _film.Year;
        public string ImageUrl => _film.ImageUrl;
    }
}