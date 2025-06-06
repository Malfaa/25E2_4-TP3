using CityBreaks.Web.Data.Service;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class FilterProperties : PageModel
{
    private readonly IPropertyService _propertyService;

    public FilterProperties(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [BindProperty(SupportsGet = true)]
    public decimal? MinPrice { get; set; }
    [BindProperty(SupportsGet = true)]
    public decimal? MaxPrice { get; set; }
    [BindProperty(SupportsGet = true)]
    public string CityName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string PropertyName { get; set; }

    public List<Property> FilteredProperties { get; set; }

    public async Task OnGetAsync()
    {
        FilteredProperties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
    }
}