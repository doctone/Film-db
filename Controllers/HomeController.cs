using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using film_db.Models;
using film_db.Repository;

namespace film_db.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFilmsRepo _films;
    private readonly IDirectorsRepo _directors;

    public HomeController(ILogger<HomeController> logger, IFilmsRepo films, IDirectorsRepo directors)
    {
        _logger = logger;
        _films = films;
        _directors = directors;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Films()
    {
        var films = _films.GetAllFilms();
        return View(films);
    }
    public IActionResult Directors()
    {
        var directors = _directors.GetAllDirectors();
        return View(directors);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
