#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor
{
    [Authorize(Roles = "Owner")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public CreateModel(Hotel_Advisor.Data.Hotel_AdvisorContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["Country"] = new SelectList(_context.Countries, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var emptyHotel = new Hotel { UserID = userId };

            if (await TryUpdateModelAsync<Hotel>(
                    emptyHotel,
                    "hotel",
                    h => h.CountryID,
                    h => h.Name,
                    h => h.Description,
                    h => h.Address,
                    h => h.City,
                    h => h.Website,
                    h => h.CovidSafety))
            {
                _context.Hotels.Add(emptyHotel);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Hotels");
        }
    }
}
