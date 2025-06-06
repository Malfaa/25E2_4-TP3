namespace CityBreaks.Web.Data.Service;

public interface IPropertyService
{
    Task <bool> SoftDeleteAsync(int id);
}