///////////////////////////////////////////////////////////////////////////////////////////////////
/// Tutorial: Get started with Razor Pages in ASP.NET Core
/// https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-8.0&tabs=visual-studio
///////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _01_07_2025_tutorial_razor_pages.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<_01_07_2025_tutorial_razor_pagesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_01_07_2025_tutorial_razor_pagesContext") ?? throw new InvalidOperationException("Connection string '_01_07_2025_tutorial_razor_pagesContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
//app.UseStaticFiles(); // Serve static files (e.g., CSS, JavaScript, images)
app.UseRouting(); // Adds route matching to the middleware pipeline

app.UseAuthorization(); // Authorizes a user to access secure resources (not used in this example app, could be removed)

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run(); // Run the application
