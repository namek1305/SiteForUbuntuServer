namespace MyWebApp.Models
{
    public class AnimeCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string AnimeTitle { get; set; } = default!;
        public bool IsProtagonist { get; set; }
    }
}