using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data.Service;

public class PropertyService : IPropertyService
{
    private readonly CityBreaksContext _context;
		
    public PropertyService(CityBreaksContext context)
    {
        _context = context;
    }
		
    public async Task<bool> SoftDeleteAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property != null)
        {
            property.DeletedAt = DateTime.UtcNow;
            _context.Properties.Update(property);
        }

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }catch(Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }
    public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName)
    {
        
        IQueryable<Property> query = _context.Properties
            .Include(p => p.City)    
            .ThenInclude(c => c.Country);

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.PricePerNight >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.PricePerNight <= maxPrice.Value);
        }

        if (!string.IsNullOrWhiteSpace(cityName))
        {
            query = query.Where(p => p.City.Name.Contains(cityName));
        }

        if (!string.IsNullOrWhiteSpace(propertyName))
        {
            query = query.Where(p => p.Name.Contains(propertyName));
        }

        return await query.OrderBy(p => p.Name).ToListAsync();
    }
}