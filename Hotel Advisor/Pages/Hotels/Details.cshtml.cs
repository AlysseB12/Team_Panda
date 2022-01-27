#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel_Advisor.Data;
using Hotel_Advisor.Models;

namespace Hotel_Advisor
{
    public class DetailsModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public DetailsModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int hotelId)
        {
            Hotel = await _context.Hotels
                .Include(h => h.Country)
                .Include(h => h.User).FirstOrDefaultAsync(m => m.ID == hotelId);

            if (Hotel == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
