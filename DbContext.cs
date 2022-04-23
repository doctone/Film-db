using film_db.Models;
using Microsoft.EntityFrameworkCore;

namespace film_db
{
    public class FilmContext  : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=FilmDB;Trusted_Connection=True;");
        }
    }
}