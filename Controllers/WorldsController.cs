using WorldWorkshopApi.Models;
using WorldWorkshopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace WorldWorkshopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorldsController: ControllerBase 
{
    private readonly WorldsService _worldsService;

    public WorldsController(WorldsService worldsService) => _worldsService = worldsService;

    [HttpGet]
    public async Task<List<World>> Get() => await _worldsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<World>> Get(string id)
    {
        var world = await _worldsService.GetAsync(id);

        if (world is null)
        {
            return NotFound();
        }

        return world;
    }

    [HttpPost]
    public async Task<IActionResult> Post(World newWorld)
    {
        await _worldsService.CreateAsync(newWorld);
        
        return CreatedAtAction(nameof(Get), new {id = newWorld.Id}, newWorld);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, World updatedWorld)
    {
        var world = await _worldsService.GetAsync(id);

        if (world is null)
        {
            return NotFound();
        }

        updatedWorld.Id = world.Id;

        await _worldsService.UpdateAsync(id, updatedWorld);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var world = await _worldsService.GetAsync(id);

        if (world is null)
        {
            return NotFound();
        }

        await _worldsService.RemoveAsync(id);

        return NoContent();
    }


}