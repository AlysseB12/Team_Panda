using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public string UserID { get; set; }
        public IdentityUser User { get; set; }

    }
}
