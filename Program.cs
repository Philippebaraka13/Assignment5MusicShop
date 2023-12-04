using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment5MusicShop.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Assignment5MusicShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment5MusicShopContext") ?? throw new InvalidOperationException("Connection string 'Assignment5MusicShopContext' not found.")));

// Add session services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // You can set a different timeout value
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Indicates that the cookie should not be subject to consent checks
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Important: UseSession() must be called before UseEndpoints() and after UseRouting()
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
