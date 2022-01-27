using Microsoft.EntityFrameworkCore;
using Hotel_Advisor.Data;
using Hotel_Advisor.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Hotel_AdvisorContextConnection");builder.Services.AddDbContext<Hotel_AdvisorContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultUI()
    .AddEntityFrameworkStores<Hotel_AdvisorContext>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Hotel_AdvisorContext>();
    context.Database.Migrate();

    await Hotel_Advisor.Areas.Identity.Data.DbInitializer.Initialize(context, services);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();