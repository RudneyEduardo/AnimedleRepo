using animedle.Models;
using animedle.Services;
using Microsoft.AspNetCore.Mvc;

namespace animedle.Controllers;

[ApiController]
[Route("animes/[controller]")]
public class AnimesController : ControllerBase
{
    private readonly AnimeService _animeService;

    public AnimesController(AnimeService animeService) =>
        _animeService = animeService;

    [HttpGet]
    public async Task<List<Anime>> Get() =>
        await _animeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Anime>> Get(string id)
    {
        var anime = await _animeService.GetAsync(id);

        if (anime is null)
        {
            return NotFound();
        }

        return anime;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Anime newAnime)
    {
        await _animeService.CreateAsync(newAnime);

        return CreatedAtAction(nameof(Get), new { id = newAnime.Id }, newAnime);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Anime updatedAnime)
    {
        var anime = await _animeService.GetAsync(id);

        if (anime is null)
        {
            return NotFound();
        }

        updatedAnime.Id = anime.Id;

        await _animeService.UpdateAsync(id, updatedAnime);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var anime = await _animeService.GetAsync(id);

        if (anime is null)
        {
            return NotFound();
        }

        await _animeService.RemoveAsync(id);

        return NoContent();
    }
}