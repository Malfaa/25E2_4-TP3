using CityBreaks.Web.Data.Service;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class CityDetails : PageModel
{
    private readonly ICityService _cityService;
    private readonly IPropertyService _propertyService;

    public City City { get; set; } 

    public CityDetails(ICityService cityService, IPropertyService propertyService)
    {
        _cityService = cityService;
        _propertyService = propertyService;
    }

    public async Task<IActionResult> OnGetAsync(string name)
    {
        City = await _cityService.GetByNameAsync(name);

        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int propertyId, string cityName)
    {
        var success = await _propertyService.SoftDeleteAsync(propertyId);

        if (success)
        {
            TempData["SuccessMessage"] = "Propriedade marcada como excluída com sucesso!";
        }
        else
        {
            TempData["ErrorMessage"] = "Não foi possível marcar a propriedade como excluída.";
        }

        return RedirectToPage(new { name = cityName });
    }
}