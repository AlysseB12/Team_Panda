#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_Advisor
{
    [Authorize(Roles = "Owner")]
    public class CreateModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public CreateModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryID"] = new SelectList(_context.Countries, "ID", "ID");
        ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hotels.Add(Hotel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
