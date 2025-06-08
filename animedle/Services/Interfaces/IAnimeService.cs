using animedle.Models;

namespace animedle.Services.Interfaces;
public interface IAnimeService
{
    Task<List<Anime>> GetAllAsync();
    Task<Anime?> GetByIdAsync(string id);
    Task CreateAsync(Anime anime);
    Task UpdateAsync(string id, Anime anime);
    Task RemoveAsync(string id);
    Task<bool> CheckIfExistsAsync(string id);
}
