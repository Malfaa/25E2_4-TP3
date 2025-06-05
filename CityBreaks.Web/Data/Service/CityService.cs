using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data.Service;

public class CityService : ICityService
{
    private readonly CityBreaksContext _context;
	
    public CityService(CityBreaksContext context)
    {
        _context = context;
    }
	
    public async Task<List<City>> GetAllAsync()
    {
        var cities = await _context.Cities
            .Include(city => city.Country)
            .Include(city => city.Properties)
            .ToListAsync();
        return cities;
    }

    public async Task<City> GetByNameAsync(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            return null;
        }
        var cities = await _context.Cities
            .Include(city => city.Country)
            .Include(city=> city.Properties)
            .FirstOrDefaultAsync(c => EF.Functions.Collate(c.Name, "NOCASE") == name);

        return cities ?? throw new InvalidOperationException();
    }
}