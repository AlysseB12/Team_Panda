using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Models
{
    public class ApplicationRole : IdentityRole
    {
    

        public int RoleID { get; set; }
        public Roles Type { get; set; }

    }

    public enum Roles
    {
        Admin, 
        Premium,
        Standard 
    }
}
