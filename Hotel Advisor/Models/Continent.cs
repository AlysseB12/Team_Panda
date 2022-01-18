namespace Hotel_Advisor.Models
{
    public class Continent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set;}
    }
}
