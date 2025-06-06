using CityBreaks.Web.Data.Configurations;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data;

public class CityBreaksContext : DbContext
{
    public CityBreaksContext()
    {
        
    }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Property> Properties { get; set; }

    public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());

        modelBuilder.Entity<Property>().HasQueryFilter(p => p.DeletedAt == null);
    }
    
}