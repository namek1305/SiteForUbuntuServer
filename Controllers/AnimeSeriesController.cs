using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

[ApiController]
[Route("api/[controller]")]
public class AnimeSeriesController : ControllerBase
{
    private static readonly List<AnimeSeries> _animeList = new()
    {
        new AnimeSeries { Id = 1, Title = "Attack on Titan", EpisodeCount = 87, Rating = 9.0 },
        new AnimeSeries { Id = 2, Title = "Demon Slayer", EpisodeCount = 55, Rating = 8.7 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<AnimeSeries>> GetAll() => _animeList;
}
