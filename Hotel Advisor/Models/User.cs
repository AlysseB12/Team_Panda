namespace Hotel_Advisor.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Owner { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Review_Like> Review_Likes { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
