using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Data;
using CityBreaks.Web.Models; 

namespace CityBreaks.Web.Pages
{
    public class EditProperty : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditProperty(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public SelectList CityDropdown { get; set; } 

        public string CurrentCityName { get; private set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = (await _context.Properties
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id))!;

            if (Property == null)
            {
                return NotFound();
            }

            CurrentCityName = Property.City.Name;

            await PopulateDropdown(Property.CityId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propertyToUpdate = await _context.Properties.FindAsync(id);

            if (propertyToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                    propertyToUpdate,
                    "Property",
                    p => p.Name, p => p.PricePerNight, p => p.CityId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/CityDetails", new { name = (await _context.Cities.FindAsync(propertyToUpdate.CityId))?.Name });
            }

            await PopulateDropdown(propertyToUpdate.CityId);

            return Page();
        }

        private async Task PopulateDropdown(object? selectedCity = null)
        {
            var citiesQuery = _context.Cities.OrderBy(c => c.Name);
            CityDropdown = new SelectList(await citiesQuery.AsNoTracking().ToListAsync(), "Id", "Name", selectedCity);
        }
    }
}