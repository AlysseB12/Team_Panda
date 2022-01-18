using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Advisor.Data;

public class Hotel_AdvisorContext : IdentityDbContext<IdentityUser>
{
    public Hotel_AdvisorContext(DbContextOptions<Hotel_AdvisorContext> options)
        : base(options)
    {
        
}
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewLike> ReviewLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Hotel>().ToTable(nameof(Hotel));
        builder.Entity<Continent>().ToTable(nameof(Continent));
        builder.Entity<Country>().ToTable(nameof(Country));
        builder.Entity<Favourite>().ToTable(nameof(Favourite));
        builder.Entity<Review>().ToTable(nameof(Review));
        builder.Entity<ReviewLike>().ToTable(nameof(ReviewLike));

        builder.Entity<Favourite>().HasOne(h=>h.Hotel).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Hotel>().HasMany(h => h.Reviews).WithOne(f => f.Hotel).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ReviewLike>().HasOne(h => h.User).WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}
