using animedle.Models;
using animedle.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace animedle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimesController : ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimesController(IAnimeService animeService) =>
        _animeService = animeService;

    [HttpGet]
    public async Task<ActionResult<List<Anime>>> GetAll() =>
        Ok(await _animeService.GetAllAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Anime>> GetById(string id)
    {
        var anime = await _animeService.GetByIdAsync(id);
        return anime is null ? NotFound() : Ok(anime);
    }

    [HttpPost]
    public async Task<ActionResult<Anime>> Create(Anime newAnime)
    {
        await _animeService.CreateAsync(newAnime);
        return CreatedAtAction(nameof(GetById), new { id = newAnime.Id }, newAnime);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Anime updatedAnime)
    {
        var exists = await _animeService.CheckIfExistsAsync(id);
        if (!exists)
            return NotFound();

        updatedAnime.Id = id;
        await _animeService.UpdateAsync(id, updatedAnime);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var exists = await _animeService.CheckIfExistsAsync(id);
        if (!exists)
            return NotFound();

        await _animeService.RemoveAsync(id);
        return NoContent();
    }
}
