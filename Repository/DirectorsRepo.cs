using film_db.Models;

namespace film_db.Repository
{
    public interface IDirectorsRepo
    {
        List<Director> GetAllDirectors();
        ExtendedDirectorResponse GetById(int id);
        Director Create(CreateDirectorRequest director);
        void Delete (int id);
        List<Film> GetFilms(int id);
    }

    public class DirectorsRepo : IDirectorsRepo
    {
        private FilmContext _context = new FilmContext();
        public List<Director> GetAllDirectors()
        {
            return _context.Directors.ToList();
        }

        public ExtendedDirectorResponse GetById(int id)
        {
            var director = _context.Directors.Single(d => d.Id == id);
            var films = GetFilms(id);
            var extDirector = new ExtendedDirectorResponse
            {
                Id = director.Id,
                Firstname = director.Firstname,
                Surname = director.Surname,
                Age = director.Age,
                Films = films,
                PhotoUrl = director.PhotoUrl
            };
            return extDirector;
        }

        public Director Create(CreateDirectorRequest director)
        {
            var result = _context.Directors.Add(new Director
            {
                Id = director.Id,
                Firstname = director.Firstname,
                Surname = director.Surname,
                Age = director.Age,
                PhotoUrl = director.PhotoUrl
            });
            _context.SaveChanges();
            return result.Entity;
        }

        public void Delete(int id)
        {
            var director = _context.Directors.Single(d => d.Id == id);
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

        public List<Film> GetFilms(int id)
        {
            var director = _context.Directors.Single(d => d.Id == id);
            return _context.Films
            .Where(film => film.Director == director).ToList();
        }
    }
}