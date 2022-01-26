using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Advisor.Pages;

public class FavouritesModel : PageModel
{
    private readonly ILogger<FavouritesModel> _logger;

    public FavouritesModel(ILogger<FavouritesModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

