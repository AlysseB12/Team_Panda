﻿using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string CovidSafety { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}

