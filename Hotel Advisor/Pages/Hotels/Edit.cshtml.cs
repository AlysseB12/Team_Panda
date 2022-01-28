#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Advisor.Models;

namespace Hotel_Advisor
{
    public class EditModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public EditModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = await _context.Hotels
                .Include(h => h.Country)
                .Include(h => h.User).FirstOrDefaultAsync(m => m.ID == id);

            if (Hotel == null)
            {
                return NotFound();
            }

            ViewData["CountryID"] = new SelectList(_context.Countries, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Hotel>(
                    hotel,
                    "hotel",
                    h => h.CountryID,
                    h => h.Name,
                    h => h.Description,
                    h => h.Address,
                    h => h.City,
                    h => h.Website,
                    h => h.CovidSafety))
            {
                await _context.SaveChangesAsync();
            }

            return Redirect("/Hotels");
        }
    }
}
