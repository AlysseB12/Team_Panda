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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor
{
    [Authorize(Roles = "Owner")]
    public class IndexModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(Hotel_Advisor.Data.Hotel_AdvisorContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Hotel> Hotel { get;set; }

        public async Task OnGetAsync()
        {
            string userId = _userManager.GetUserId(HttpContext.User);

            Hotel = await _context.Hotels
                .Where(h => h.UserID.Equals(userId))
                .Include(h => h.Country)
                .Include(h => h.User).ToListAsync();
        }
    }
}
