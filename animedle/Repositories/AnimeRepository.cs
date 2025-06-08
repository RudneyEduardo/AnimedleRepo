using animedle.Models;
using animedle.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace animedle.Repositories;

public class AnimeRepository : IAnimeRepository
{
    private readonly IMongoCollection<Anime> _animesCollection;

    public AnimeRepository(IOptions<AnimeDbSettings> AnimeDbSettings)
    {
        var mongoClient = new MongoClient(
            AnimeDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            AnimeDbSettings.Value.DatabaseName);

        _animesCollection = mongoDatabase.GetCollection<Anime>(
            AnimeDbSettings.Value.AnimeCollectionName);
    }

    public async Task<List<Anime>> GetAsync() =>
        await _animesCollection.Find(_ => true).ToListAsync();

    public async Task<Anime?> GetAsync(string id) =>
        await _animesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Anime newAnime) =>
        await _animesCollection.InsertOneAsync(newAnime);

    public async Task UpdateAsync(string id, Anime updatedAnime) =>
        await _animesCollection.ReplaceOneAsync(x => x.Id == id, updatedAnime);

    public async Task RemoveAsync(string id) =>
        await _animesCollection.DeleteOneAsync(x => x.Id == id);
}
