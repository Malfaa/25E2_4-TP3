using CityBreaks.Web.Data.Service;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICityService _cityService;
    public List<City> Cities { get; set; }
				
    public IndexModel(ICityService cityService)
    {
        _cityService = cityService;
    }

    public async Task OnGetAsync()
    {
        Cities = await _cityService.GetAllAsync();
    }
}