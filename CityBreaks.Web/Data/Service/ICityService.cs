using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Service;

public interface ICityService {
    Task<List<City>> GetAllAsync();
}