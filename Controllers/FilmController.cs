using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using film_db.Models;
using film_db.Repository;

namespace film_db.Controllers;

public class FilmController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFilmsRepo _films;

    public FilmController(ILogger<HomeController> logger, IFilmsRepo films)
    {
        _logger = logger;
        _films = films;
    }

    [HttpGet("films")]
    public ActionResult<List<Film>> GetAllFilms()
    {
        return _films.GetAllFilms();
    }

    [HttpPost("films/create")]
    public IActionResult Create([FromBody] CreateFilmRequest newFilm)
    {
         if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        var Film = _films.Create(newFilm);
        var FilmResponse = new FilmResponse(Film);
        return Created("/", FilmResponse);
    }

    [HttpDelete("films/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _films.Delete(id);
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
