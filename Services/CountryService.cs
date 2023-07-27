using open_spot_api.Models;
using open_spot_api.Data;

namespace open_spot_api.Services;

public class CountryService : ICountryService
{
    OpenSpotContext context;
    public CountryService(OpenSpotContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Country> Get()
    {
        return context.Countries;
    }
    public async Task Save(Country country)
    {
        context.Add(country);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Country country)
    {
        var current = context.Countries.Find(id);

        if (current != null)
        {
            current.Name = country.Name;
            current.Description = country.Description;

            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var current = context.Countries.Find(id);

        if (current != null)
        {
            context.Remove(current);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICountryService
{
    IEnumerable<Country> Get();
    Task Save(Country country);
    Task Update(Guid id, Country country);
    Task Delete(Guid id);
}