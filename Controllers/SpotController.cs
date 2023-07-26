using Microsoft.AspNetCore.Mvc;
using open_spot_api.Data;
using open_spot_api.Models;
using open_spot_api.Services;

namespace open_spot_api.Controllers;

[Route("api/[controller]")]
public class SpotController : ControllerBase
{
    ISpotService spotService;
    OpenSpotContext dbcontext;

    public SpotController(ISpotService service, OpenSpotContext _dbcontext)
    {
        spotService = service;
        dbcontext = _dbcontext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(spotService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Spot spot)
    {
        spotService.Save(spot);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Spot spot)
    {
        spotService.Update(id, spot);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        spotService.Delete(id);
        return Ok();
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}