namespace animedle.Models;

public class AnimeDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string AnimeCollectionName { get; set; } = null!;
}