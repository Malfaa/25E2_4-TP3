using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class CreateProperty : PageModel
    {
        private readonly CityBreaksContext _context; 

        public CreateProperty(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property NewProperty { get; set; } = new(); 

        public SelectList CityDropdown { get; set; }

        public async Task OnGetAsync()
        {
            await PopulateDropdown();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                await PopulateDropdown();
                return Page();
            }

            _context.Properties.Add(NewProperty);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/CityDetails", new { name = (await _context.Cities.FindAsync(NewProperty.CityId))?.Name });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await PopulateDropdown();
                return Page();
            }
        }

        private async Task PopulateDropdown()
        {
            var cities = await _context.Cities
                                     .OrderBy(c => c.Name)
                                     .Select(c => new { c.Id, c.Name })
                                     .ToListAsync();
            CityDropdown = new SelectList(cities, nameof(City.Id), nameof(City.Name));
        }
    }