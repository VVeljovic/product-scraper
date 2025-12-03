using Microsoft.EntityFrameworkCore;
using ProductScraper.Data;
using ProductScraper.Services.LLM;
using ProductScraper.Services.Scrapers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IScrape, Scraper>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();

builder.Services.AddDbContext<ScrapingDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Scrape}/{action=Index}/{id?}");

app.Run();
