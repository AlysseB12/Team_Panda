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
    public class IndexModel : PageModel
    {
        private readonly Hotel_Advisor.Data.Hotel_AdvisorContext _context;

        public IndexModel(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; }

        public async Task OnGetAsync()
        {
            Hotel = await _context.Hotels
                .Include(h => h.Country)
                .Include(h => h.User).ToListAsync();
        }
    }
}
