using animedle.Models;
using animedle.Repositories.Interfaces;
using animedle.Services.Interfaces;

namespace animedle.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public Task<List<Anime>> GetAllAsync() =>
        _animeRepository.GetAsync();

    public Task<Anime?> GetByIdAsync(string id) =>
        _animeRepository.GetAsync(id);

    public async Task<Boolean> CheckIfExistsAsync(string id)
    {
        var anime = await _animeRepository.GetAsync(id);
        if (anime == null)
        {
            return false;
        }
        return true;
    }
        

    public Task CreateAsync(Anime anime) =>
        _animeRepository.CreateAsync(anime);

    public Task UpdateAsync(string id, Anime updatedAnime) =>
        _animeRepository.UpdateAsync(id, updatedAnime);

    public Task RemoveAsync(string id) =>
        _animeRepository.RemoveAsync(id);
}
