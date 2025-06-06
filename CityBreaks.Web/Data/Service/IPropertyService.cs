using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Service;

public interface IPropertyService
{
    Task <bool> SoftDeleteAsync(int id);
    Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName);

}