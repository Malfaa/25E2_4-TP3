using CityBreaks.Web.Data.Service;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class CityDetails : PageModel
{
    private readonly ICityService _cityService;

    public City City { get; set; } 

    public CityDetails(ICityService cityService)
    {
        _cityService = cityService;
    }

    public async Task<IActionResult> OnGetAsync(string name)
    {
        City = await _cityService.GetByNameAsync(name);

        return Page();
    }
}