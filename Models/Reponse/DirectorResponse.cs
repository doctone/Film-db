namespace film_db.Models
{
    public class DirectorResponse
    {
        private readonly Director _director;

        public DirectorResponse(Director director)
        {
            _director = director;
        }
        public int Id => _director.Id;
        public string? Firstname => _director.Firstname;
        public string? Surname => _director.Surname;
        public int Age => _director.Age;
        public string PhotoUrl => _director.PhotoUrl;
    }
}