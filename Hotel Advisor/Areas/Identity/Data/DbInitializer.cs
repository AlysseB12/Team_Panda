using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Advisor.Areas.Identity.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(Hotel_Advisor.Data.Hotel_AdvisorContext context, IServiceProvider services)
        {
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Standard", "Owner" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (context.Continents.Any())
            {
                return;
            }

            var Continents = new Continent[]
            {
                new Continent{Name="Europe"},
                new Continent{Name="Asia"},
                new Continent{Name="Africa"},
                new Continent{Name="Oceania"},
                new Continent{Name="North America"},
                new Continent{Name="South America"},
                new Continent{Name="Antartica"}
            };

            context.Continents.AddRange(Continents);
            context.SaveChanges();

            var Countries = new Country[]
                {
                    new Country{ContinentID=6, Name="Argentina" , CountryCode="AR"},
                    new Country{ContinentID=6, Name="Bolivia" , CountryCode="BO"},
                    new Country{ContinentID=6, Name="Brazil" , CountryCode="BR"},
                    new Country{ContinentID=6, Name="Chile" , CountryCode="CL"},
                    new Country{ContinentID=6, Name="Colombia" , CountryCode="CO"},
                    new Country{ContinentID=6, Name="Ecuador" , CountryCode="EC"},
                    new Country{ContinentID=6, Name="Falkland Islands" , CountryCode="FK"},
                    new Country{ContinentID=6, Name="French Guiana" , CountryCode="GF"},
                    new Country{ContinentID=6, Name="Guyana" , CountryCode="GY"},
                    new Country{ContinentID=6, Name="Peru" , CountryCode="PE"},
                    new Country{ContinentID=6, Name="Paraguay" , CountryCode="PY"},
                    new Country{ContinentID=6, Name="Suriname" , CountryCode="SR"},
                    new Country{ContinentID=6, Name="Uruguay" , CountryCode="UY"},
                    new Country{ContinentID=6, Name="Venezuela" , CountryCode="VE"},

                };

            context.Countries.AddRange(Countries);
            context.SaveChanges();

            var User = new ApplicationUser
            {
                Id = "a93f6a42-1b45-4e9b-805c-ae73b79d6cd3",
                UserName = "alysse@test.co.uk",
                NormalizedUserName = "ALYSSE@TEST.CO.UK",
                Email = "alysse@test.co.uk",
                NormalizedEmail = "ALYSSE@TEST.CO.UK",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEBAZn/GfonIhwSZZ71auZYdYMN4s9XvQ7YebAfA5z0cUxrFqv9I5VBaJt6Qii2Wydg==",
                SecurityStamp = "7I5DE4E3QOUWDI6VDWTYC76RXK2VO3GD",
                ConcurrencyStamp = "6b6459d7-9dab-480f-a4f1-90a673b33dc7",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            context.Users.Add(User);
            context.SaveChanges();

            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await userManager.AddToRoleAsync(User, "Owner");

            var Hotels = new Hotel[]
            {
                new Hotel{CountryID= 3,
                   UserID= "a93f6a42-1b45-4e9b-805c-ae73b79d6cd3" ,
                   Name= "Bem-vindo a casa",
                   Description="Come stay at the best hotel in Brazil, our house is your house so relax and enjoy your stay",
                   Address="Largo Vespasiano Julio Veppo 77, Center ",
                   City="Porto Alegre",
                   Website="www.Bem-vida-Casa.com",
                   CovidSafety="Masks are mandatory while moving around the hotel, Sanitary stations throughout, Extra routine cleaning"}  
            };

            context.Hotels.AddRange(Hotels);
            context.SaveChanges();
        }
    }
}
