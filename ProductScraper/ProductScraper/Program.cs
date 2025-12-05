using Microsoft.EntityFrameworkCore;
using ProductScraper.Data;
using ProductScraper.Helpers;
using ProductScraper.Services.LLM;
using ProductScraper.Services.Scrapers;
using ProductScraper.Services.UrlBuilders.Factory;
using ProductScraper.Services.UrlBuilders.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IScrape, Scraper>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<AnanasUrlBuilder>();
builder.Services.AddScoped<GigatronUrlBuilder>();
builder.Services.AddScoped<EPlanetaUrlBuilder>();

builder.Services.AddScoped<IReadOnlyDictionary<string, Func<IUrlBuilderStrategy>>>(sp => new Dictionary<string, Func<IUrlBuilderStrategy>>
{
    [Constants.Ananas.Name] = () => sp.GetRequiredService<AnanasUrlBuilder>(),
    [Constants.Gigatron.Name] = () => sp.GetRequiredService<GigatronUrlBuilder>(),
    [Constants.EPlaneta.Name] = () => sp.GetRequiredService<EPlanetaUrlBuilder>()
});

builder.Services.AddScoped<IUrlBuilderFactory, UrlBuilderFactory>();
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
