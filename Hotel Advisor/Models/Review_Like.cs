namespace Hotel_Advisor.Models
{
    public class Review_Like
    {
        public int ID { get; set; }
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public DateTime DateCreated { get; set; } 

    }
}
