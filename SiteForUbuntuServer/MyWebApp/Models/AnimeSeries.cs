namespace MyWebApp.Models
{
    public class AnimeSeries
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public int EpisodeCount { get; set; }
        public double Rating { get; set; }
    }
}