using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

[ApiController]
[Route("api/[controller]")]
public class AnimeCharactersController : ControllerBase
{
    private static readonly List<AnimeCharacter> _characters = new()
    {
        new AnimeCharacter { Id = 1, Name = "Eren Yeager", AnimeTitle = "Attack on Titan", IsProtagonist = true },
        new AnimeCharacter { Id = 2, Name = "Nezuko Kamado", AnimeTitle = "Demon Slayer", IsProtagonist = false }
    };

    [HttpGet]
    public ActionResult<IEnumerable<AnimeCharacter>> GetAll() => _characters;
}