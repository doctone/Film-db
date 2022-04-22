using film_db.Models;
using Microsoft.EntityFrameworkCore;

namespace film_db.Repository
{
    public interface IFilmsRepo
    {
        List<Film> GetAllFilms();
        Film GetById(int id);
        Film Create(CreateFilmRequest Film);
        void Delete (int id);
    }

    public class FilmsRepo : IFilmsRepo
    {
        private FilmContext _context = new FilmContext();
        public List<Film> GetAllFilms()
        {
            return _context.Films.Include(f => f.Director).ToList();
        }

        public Film GetById(int id)
        {
            return _context.Films.Single(d => d.Id == id);
        }

        public Film Create(CreateFilmRequest Film)
        {
            var result = _context.Films.Add(new Film
            {
                Id = Film.Id,
                Title = Film.Title,
                DirectorId = Film.DirectorId,
                ImageUrl = Film.ImageUrl,
                Year = Film.Year,
            });
            _context.SaveChanges();
            return result.Entity;
        }

        public void Delete(int id)
        {
            var Film = GetById(id);
            _context.Films.Remove(Film);
            _context.SaveChanges();
        }
    }
}