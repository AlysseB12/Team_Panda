using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Advisor.Pages.Map
{
    public class ContinentsModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public ContinentsModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        public IList<Country> Countries { get; set; }
        public Continent? Continent { get; set; }

        public IActionResult OnGet(int continentId)
        {
            Continent = _context.Continents.FirstOrDefault(c => c.ID == continentId);

            if (Continent == null)
            {
                return NotFound();
            }

            Countries = _context.Countries
                .Where(c => c.ContinentID == continentId).ToList();

            return Page();
        }
    }
}
