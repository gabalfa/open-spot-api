namespace open_spot_api.Models;

public class Spot
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Location { get; set; }
    public string[]? Sports { get; set; }
    public string[]? Images { get; set; }
}