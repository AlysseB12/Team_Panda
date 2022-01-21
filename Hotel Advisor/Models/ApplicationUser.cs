using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
