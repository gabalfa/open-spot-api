
using Microsoft.EntityFrameworkCore;
using open_spot_api.Models;

namespace open_spot_api.Data
{
    public class OpenSpotContext : DbContext
    {
        public OpenSpotContext(DbContextOptions<OpenSpotContext> options) : base(options) { }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Country> Countries { get; set; }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)  
        // {
        // List<Spot> spotsInit = new List<Spot>();
        // spotsInit.Add(new Spot() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Fontanar", Description = "SkatePark"});
        // spotsInit.Add(new Spot() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Villa del Río", Description = "Street"});

        // modelBuilder.Entity<Spot>(spot => 
        // {
        //     spot.ToTable("Spots");

        //     spot.HasKey(p=> p.Id);
        //     spot.Property(p=> p.Name).IsRequired().HasMaxLength(128);
        //     spot.Property(p=> p.Description).HasMaxLength(256);

        //     spot.HasData(spotsInit);
        // });
        // }
    }

}