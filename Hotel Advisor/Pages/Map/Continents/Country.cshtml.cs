using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public Continent? Continent { get; set; }
        public Country? Country { get; set; }

        public IActionResult OnGet(int continentId, int countryId)
        {
            Continent = _context.Continents.FirstOrDefault(c => c.ID == continentId);
            Country = _context.Countries.FirstOrDefault(c => c.ID == countryId);

            if (Continent == null || Country == null)
            {
                return NotFound();
            }

            Hotels = _context.Hotels.Where(h => h.CountryID == countryId).ToList();

            return Page();
        }
    }
}
