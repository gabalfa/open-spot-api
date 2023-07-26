using open_spot_api.Models;
using open_spot_api.Data;

namespace open_spot_api.Services;

public class SpotService : ISpotService
{
    OpenSpotContext context;
    public SpotService(OpenSpotContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Spot> Get()
    {
        return context.Spots;
    }
    public async Task Save(Spot spot)
    {
        context.Add(spot);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Spot spot)
    {
        var spotActual = context.Spots.Find(id);

        if (spotActual != null)
        {
            spotActual.Name = spot.Name;
            spotActual.Description = spot.Description;

            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var spotActual = context.Spots.Find(id);

        if (spotActual != null)
        {
            context.Remove(spotActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ISpotService
{
    IEnumerable<Spot> Get();
    Task Save(Spot spot);
    Task Update(Guid id, Spot spot);
    Task Delete(Guid id);
}