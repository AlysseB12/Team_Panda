using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Advisor.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        return Redirect("/Map");
    }
}
