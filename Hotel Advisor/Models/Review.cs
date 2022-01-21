using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public string Comment { get; set; }
        public float Overall { get; set; }
        public float Value { get; set; }
        public float Service { get; set; }
        public float Location { get; set; }
        public ICollection<ReviewLike> Likes { get; set; }
    }
}
