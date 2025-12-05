using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductScraper.Data;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using System.Text.Json;
using Mapster;
using ProductScraper.Models;
using ProductScraper.Services.UrlBuilders.Factory;

namespace ProductScraper.Services.Scrapers;
using Product = Models.Product;
using ProductEntity = Data.Product;

public class Scraper(IUrlBuilderFactory factory, ScrapingDbContext scrapingDbContext) : IScrape
{
    public async Task<ScrapedResult> ScrapeProducts(QueryScrapingModel queryScrapingModel)
    {
        var siteUrlPairs = new List<SiteAndUrlPair>();
        foreach (var siteName in Constants.SiteNames)
        {
            var url = factory.GetStrategy(siteName).BuildUrl(queryScrapingModel);
            siteUrlPairs.Add(new SiteAndUrlPair(siteName, url));
        }
        return await ScrapeWorkflow(siteUrlPairs, JsonSerializer.Serialize(queryScrapingModel));
    }


    public async Task<ScrapedResult> ScrapeProducts(ScrapedResult scrapedResult)
    {
        return await ScrapeWorkflow(scrapedResult.SitenameAndNexturlPairs, scrapedResult.AppliedFiltersSerialized);
    }

    public async Task<ScrapedResult> ScrapeProducts(string category, BaseProductFilters filters)
    {
        var serializedFilters = JsonSerializer.Serialize(filters);

        if (IsAlreadyScraped(serializedFilters))
        {
            var already = GetAlreadyScrapedProducts(serializedFilters);
            return new ScrapedResult(already, new List<SiteAndUrlPair>(), serializedFilters);
        }

        var masterFilterValuePairs = GetSelectedFilters(filters);

        var siteUrlPairs = new List<SiteAndUrlPair>();

        foreach (var siteName in filters.SiteNames)
        {
            var scrapingElements = ScrapingElements.GetElementsForScraping(siteName + category);
            var urlQueryParams = GetStoreFilterValuesPairs(siteName + category, masterFilterValuePairs);
            var url = factory.GetStrategy(siteName).BuildUrl(scrapingElements, urlQueryParams);

            siteUrlPairs.Add(new SiteAndUrlPair(siteName, url));
        }

        return await ScrapeWorkflow(siteUrlPairs, serializedFilters);
    }

    private async Task<ScrapedResult> ScrapeWorkflow(IEnumerable<SiteAndUrlPair> siteUrlPairs, string filterHash)
    {
        var products = new List<Product>();
        var nextUrls = new List<SiteAndUrlPair>();

        foreach (var pair in siteUrlPairs)
        {
            var selectors = ScrapingSelectors.GetScrapingSelectors(pair.SiteName);

            using var driver = GetChromeDriver(pair.Url);

            var scraped = ScrapeProducts(pair.Url, driver, selectors);

            var nextPage = ScrapeNextPageValue(pair.Url, driver, selectors);
            if (!string.IsNullOrEmpty(nextPage))
            {
                var nextUrl = BuildNextUrl(pair.Url, nextPage, pair.SiteName);
                nextUrls.Add(new SiteAndUrlPair(pair.SiteName, nextUrl));
            }

            products.AddRange(scraped);
            await SaveProductsAsync(scraped, filterHash);
        }

        return new ScrapedResult(products, nextUrls, filterHash);
    }


    private static string BuildNextUrl(string url, string nextPageValue, string siteName)
    {
        var nextPageQueryParameter = ScrapingElements.GetNextPageQueryParameter(siteName);

        if (url[url.Length - 1] == '?')
            url.Remove(url.Length - 1);

        if (url.Contains("&" + nextPageQueryParameter))
        {
            var index = url.LastIndexOf("&" + nextPageQueryParameter);
            url = url.Remove(index);
        }


        return url + "&" + nextPageQueryParameter + "=" + nextPageValue;
    }

    private static string? ScrapeNextPageValue(string url, ChromeDriver chromeDriver, ScrapingSelectors scrapingSelectors)
    {
        var currentPageElement = chromeDriver
            .FindElements(By.CssSelector(scrapingSelectors.CurrentPage))
            .FirstOrDefault();

        var nextElement = currentPageElement?.FindElements(By.XPath("following-sibling::*[1]")).FirstOrDefault();

        if (int.TryParse(nextElement?.Text, out int pageNumber))
            return (pageNumber).ToString();

        return string.Empty;
    }

    private async Task SaveProductsAsync(List<Product> products, string filterHashValue)
    {
        var productEntities = products.Adapt<List<ProductEntity>>();
        productEntities.ForEach(x => x.FilterHash = filterHashValue);

        await scrapingDbContext.AddRangeAsync(productEntities);

        await scrapingDbContext.SaveChangesAsync();
    }

    private static ChromeDriver GetChromeDriver(string finalUrl)
    {
        Console.WriteLine(finalUrl);

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--headless=new");

        var driver = new ChromeDriver(chromeOptions);

        driver.Navigate().GoToUrl(finalUrl);

        return driver;
    }

    private static List<Product> ScrapeProducts(string url, ChromeDriver driver, ScrapingSelectors s)
    {
        if (!ProductsExist(driver, s, url))
            return new List<Product>();

        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(d => d.FindElements(By.CssSelector(s.LinkClass)).Count > 0);

        return driver.FindElements(By.CssSelector(s.DivClass))
            .Select(div => new Product(
                div.FindElement(By.CssSelector(s.TitleClass))?.Text.Trim() ?? string.Empty,
                div.FindElements(By.CssSelector(s.PriceClass)).FirstOrDefault()?.Text.Trim() ?? string.Empty,
                div.FindElement(By.CssSelector(s.LinkClass)).GetAttribute("href") ?? string.Empty,
                null
            ))
            .ToList();
    }

    private static bool ProductsExist(ChromeDriver driver, ScrapingSelectors scrapingSelectors, string url)
    {
        return !driver.FindElements(By.CssSelector(scrapingSelectors.ProductsNotFoundClass)).Any() && driver.Url.ToLower() == url.ToLower();
    }

    private bool IsAlreadyScraped(string hashValue)
    {
        return scrapingDbContext.Products.Any(x => x.FilterHash == hashValue);
    }

    private List<Product> GetAlreadyScrapedProducts(string hashValue)
    {
        var productEntities = scrapingDbContext.Products.Where(x => x.FilterHash == hashValue).ToList();

        return productEntities.Adapt<List<Product>>();
    }

    private static Dictionary<string, List<string>> GetSelectedFilters(BaseProductFilters filters)
    {
        var properties = filters.GetType()
            .GetProperties()
            .Where(p => p.Name != nameof(BaseProductFilters.SiteNames));

        var filterValuesPairs = new Dictionary<string, List<string>>();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(filters);
            if (value is null)
                continue;

            if (value is List<string> list)
            {
                if (list.Count > 0)
                    filterValuesPairs[prop.Name] = list;
                continue;
            }

            if (value is decimal dec && dec == 0)
                continue;

            var stringValue = Convert.ToString(value);
            if (!string.IsNullOrWhiteSpace(stringValue))
                filterValuesPairs[prop.Name] = new List<string> { stringValue };
        }

        return filterValuesPairs;
    }

    private Dictionary<string, List<string>> GetStoreFilterValuesPairs(string siteNameCategoryName, Dictionary<string, List<string>> masterFilterValuePairs)
    {
        var urlQueryParams = new Dictionary<string, List<string>>();

        var filtersMapping = scrapingDbContext.FiltersMapping
            .Where(x => x.Store == siteNameCategoryName)
            .ToDictionary(x => x.MasterValue, x => x.StoreValue);

        if (masterFilterValuePairs.Count != 0)
        {
            foreach (var masterFilter in masterFilterValuePairs.Keys)
            {
                filtersMapping.TryGetValue(masterFilter, out var mappedFilter);

                var mappedValues = new List<string>();
                foreach (var masterValue in masterFilterValuePairs[masterFilter])
                {
                    filtersMapping.TryGetValue(masterValue, out var mappedValue);

                    if (!string.IsNullOrEmpty(mappedValue))
                        mappedValues.Add(mappedValue);

                    if (decimal.TryParse(masterValue, out var number))
                    {
                        mappedValues.Add(masterValue);
                    }
                }
                urlQueryParams.Add(mappedFilter, mappedValues);
            }
        }

        return urlQueryParams;
    }
}