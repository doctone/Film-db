using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using film_db.Models;
using film_db.Repository;

namespace film_db.Controllers;

public class DirectorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDirectorsRepo _directors;

    public DirectorController(ILogger<HomeController> logger, IDirectorsRepo directors)
    {
        _logger = logger;
        _directors = directors;
    }

    [HttpGet("directors")]
    public ActionResult<List<Director>> GetAllDirectors()
    {
        return _directors.GetAllDirectors();
    }

    [HttpGet("directors/{id}/films")]
    public ActionResult<List<Film>> GetAllFilms([FromRoute] int id)
    {
        return _directors.GetFilms(id);
    }

    [HttpGet("directors/{id}")]
    public ActionResult<ExtendedDirectorResponse> GetById([FromRoute] int id)
    {
        return _directors.GetById(id);
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateDirectorRequest newDirector)
    {
         if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        var director = _directors.Create(newDirector);
        var directorResponse = new DirectorResponse(director);
        return Created("/", directorResponse);
    }

     [HttpPatch("directors/{id}/update")]
        public ActionResult<DirectorResponse> Update([FromRoute] int id, [FromBody] UpdateDirectorRequest update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var director = _directors.Update(id, update);
            return new DirectorResponse(director);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
