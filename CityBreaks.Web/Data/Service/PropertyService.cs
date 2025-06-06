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
}