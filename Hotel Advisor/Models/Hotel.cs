using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Advisor.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Required]
        public int CountryID { get; set; }
        public Country? Country { get; set; }
        public string? UserID { get; set; }
        public ApplicationUser? User { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [Required]
        public string CovidSafety { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}

