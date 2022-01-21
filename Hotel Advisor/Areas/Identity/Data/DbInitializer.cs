using Hotel_Advisor.Models;

namespace Hotel_Advisor.Areas.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(Hotel_Advisor.Data.Hotel_AdvisorContext context)
        {
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
        }
    }
}
