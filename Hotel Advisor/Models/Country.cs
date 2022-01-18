namespace Hotel_Advisor.Models
{
    public class Country
    {
        public int ID { get; set; }
        public int ContinentID { get; set; }
        public Continent Continent { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public ICollection<Hotel> Hotels { get; set; }

    }
}
