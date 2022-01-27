using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Advisor.Pages.Map
{
    public class CountryModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public CountryModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotels { get; set; }
        public Country? Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int continentId, int countryId)
        {
            Country = await _context.Countries.Where(c => c.ID == countryId).Include(c => c.Continent).FirstOrDefaultAsync();

            if (Country == null)
            {
                return NotFound();
            }

            Hotels = _context.Hotels.Where(h => h.CountryID == countryId).ToList();

            return Page();
        }
    }
}
