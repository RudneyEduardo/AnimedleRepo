using animedle.Models;

namespace animedle.Repositories.Interfaces;

public interface IAnimeRepository
{
    Task<List<Anime>> GetAsync();
    Task<Anime?> GetAsync(string id);
    Task CreateAsync(Anime newAnime);
    Task UpdateAsync(string id, Anime updatedAnime);
    Task RemoveAsync(string id);
}
