using film_db.Models;

namespace film_db.Repository
{
    public interface IActorsRepo
    {
        List<Actor> GetAllActors();
        Actor GetById(int id);
        Actor Create(CreateActorRequest Actor);
        Actor Update(int id, UpdateActorRequest update);
        void Delete (int id);
        List<Film> GetFilms(int id);
    }

    public class ActorsRepo : IActorsRepo
    {
        private FilmContext _context = new FilmContext();
        public List<Actor> GetAllActors()
        {
            return _context.Actors.ToList();
        }

        public Actor GetById(int id)
        {
            return _context.Actors.Single(d => d.Id == id);
        }

        public Actor Create(CreateActorRequest Actor)
        {
            var result = _context.Actors.Add(new Actor
            {
                Firstname = Actor.Firstname,
                Surname = Actor.Surname,
                Dob = Actor.Dob,
                PhotoUrl = Actor.PhotoUrl
            });
            _context.SaveChanges();
            return result.Entity;
        }

        public Actor Update(int id, UpdateActorRequest update)
        {
            var Actor = _context.Actors.Single(a => a.Id == id);
            Actor.Firstname = update.Firstname;
            Actor.Surname = update.Surname;
            Actor.PhotoUrl = update.PhotoUrl;

            _context.Actors.Update(Actor);
            _context.SaveChanges();

            return Actor;
        }

        public void Delete(int id)
        {
            var Actor = _context.Actors.Single(d => d.Id == id);
            _context.Actors.Remove(Actor);
            _context.SaveChanges();
        }

        public List<Film> GetFilms(int id)
        {
            return _context.Films.ToList();
        }
    }
}