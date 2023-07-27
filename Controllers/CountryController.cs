using Microsoft.AspNetCore.Mvc;
using open_spot_api.Data;
using open_spot_api.Models;
using open_spot_api.Services;

namespace open_spot_api.Controllers;

[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    ICountryService countryService;
    OpenSpotContext dbcontext;

    public CountryController(ICountryService service, OpenSpotContext _dbcontext)
    {
        countryService = service;
        dbcontext = _dbcontext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(countryService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Country country)
    {
        countryService.Save(country);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Country country)
    {
        countryService.Update(id, country);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        countryService.Delete(id);
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