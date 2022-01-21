using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class ReviewLike
    {
        public int ID { get; set; }
        public int ReviewID { get; set; }
        public Review Review { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; } 

    }
}
