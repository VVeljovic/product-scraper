using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductScraper.Data;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using Mapster;
using ProductScraper.Models;

namespace ProductScraper.Services.Scrapers;
using Product = Models.Product;
using ProductEntity = Data.Product;

public class Scraper(ScrapingDbContext scrapingDbContext) : IScrape
{
    public async Task<ScrapedResult> Scrape(string category, BaseProductFilters filters)
    {
        var filterValuePairs = GetSelectedFilters(filters);

        var filterHashValue = GetHashValueFromFitlers(filters);

        if (!IsAlreadyScraped(filterHashValue))
        {
            var products = new List<Product>();
            var nextUrls = new List<string>();

            foreach (var siteName in Constants.SiteNames)
            {
                var urlQueryParams = BuildUrlQueryParams(siteName + category, filterValuePairs);
                var elementsForScraping = Constants.GetElementsForScraping(siteName + category);
                var url = string.Empty;
                if (siteName == Constants.Ananas.Name)
                    url = BuildAnanasScrapingUrl(elementsForScraping, urlQueryParams);
                else if (siteName == Constants.Gigatron.Name)
                    url = BuildGigatronScrapingUrl(elementsForScraping, urlQueryParams);
                else
                    url = BuildEPlanetaScrapingUrl(elementsForScraping, urlQueryParams);

                var chromeDriver = GetChromeDriver(url);

                var scrapedProducts = ScrapeProducts(url, chromeDriver, elementsForScraping.ScrapingSelectors);

                var nextPageValue = ScrapeNextPage(url, chromeDriver, elementsForScraping.ScrapingSelectors);

                if (!string.IsNullOrEmpty(nextPageValue))
                {
                    var nextUrl = BuildNextUrl(url, nextPageValue, siteName);
                    nextUrls.Add(nextUrl);
                }

                await SaveProductsAsync(products, filterHashValue);

                products.AddRange(scrapedProducts);
            }
            return new ScrapedResult(products, nextUrls);
        }

        return null;

    }

    private static string BuildNextUrl(string url, string nextPageValue, string siteName)
    {
        // skini ako je na drugu stranicu page ? 
        var nextPageQueryParameter = Constants.GetNextPageQueryParameter(siteName);

        return url + "&" + nextPageQueryParameter + "=" + nextPageValue;
    }

    private static string? ScrapeNextPage(string url, ChromeDriver chromeDriver, ScrapingSelectors scrapingSelectors)
    {
        var a = chromeDriver.FindElements(By.CssSelector(scrapingSelectors.PaginationClass))?.Select(x => x.Text).FirstOrDefault();

        if (Int32.TryParse(a, out var br))
        {
            br++;

            return br.ToString();
        }

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

    private static List<Product> ScrapeProducts(string url, ChromeDriver driver, ScrapingSelectors scrapingSelectors)
    {
        var pageSource = driver.PageSource;
        var productLists = new List<Product>();

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        if (!ProductsExist(driver, scrapingSelectors, url))
            return productLists;

        wait.Until(d => d.FindElements(By.CssSelector(scrapingSelectors.LinkClass)).Count > 0);
        var divElements = driver.FindElements(By.CssSelector(scrapingSelectors.DivClass));

        foreach (var divElement in divElements)
        {
            var title = divElement.FindElement(By.CssSelector(scrapingSelectors.TitleClass)).Text.Trim();

            var price = divElement.FindElement(By.CssSelector(scrapingSelectors.PriceClass)).Text.Trim();

            var linkElement = divElement.FindElement(By.CssSelector(scrapingSelectors.LinkClass));
            if (linkElement == null)
                continue;
            var link = linkElement.GetAttribute("href");

            productLists.Add(new Product(title, price, link, null));
        }

        return productLists;
    }

    private static bool PaginationExist(ChromeDriver driver, ScrapingSelectors scrapingSelectors)
    {
        return driver.FindElements(By.CssSelector(scrapingSelectors.PaginationClass)).Any();
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

    private static string GetHashValueFromFitlers(BaseProductFilters filters)
    {
        using (var md5 = MD5.Create())
        {
            var serializedFilters = JsonSerializer.Serialize(filters);

            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(serializedFilters));

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }

    private static Dictionary<string, List<string>> GetSelectedFilters(BaseProductFilters filters)
    {
        var type = filters.GetType();

        var props = type.GetProperties();
        var filterValuePairs = new Dictionary<string, List<string>>();
        foreach (var prop in props)
        {
            var value = prop.GetValue(filters);

            if (value is null)
                continue;

            else if (value is List<string> list)
            {
                filterValuePairs.Add(prop.Name, list);
            }

            else if ((decimal)value == 0)
                continue;

            else
            {
                var stringValue = Convert.ToString(value);
                filterValuePairs.Add(prop.Name, new List<string> { stringValue });
            }
        }

        return filterValuePairs;
    }

    private Dictionary<string, List<string>> BuildUrlQueryParams(string siteNameCategoryName, Dictionary<string, List<string>> masterFilterValuePairs)
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

    private static string BuildAnanasScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var queryParam in urlQueryParams)
        {
            if (queryParam.Key == "brand")
            {
                var i = 0;
                var vls = queryParam.Value;
                foreach (var value in vls)
                {
                    var encodedKey = HttpUtility.UrlEncode($"{Constants.Ananas.Phones.Brend}[{i}]");
                    var encodedValue = HttpUtility.UrlEncode(value);
                    urlParams.Add($"{encodedKey}={encodedValue}");
                    i++;
                }
                continue;
            }

            if (queryParam.Key == "price")
            {
                var encodedKey = HttpUtility.UrlEncode(queryParam.Key);
                var encodedMinPrice = HttpUtility.UrlEncode(queryParam.Value.First());
                var encodedMaxPrice = HttpUtility.UrlEncode(urlQueryParams["MaxPrice"].First());
                urlQueryParams.Remove("MaxPrice");
                urlParams.Add($"{encodedKey}={encodedMinPrice}%3A{encodedMaxPrice}");
                continue;
            }

            else
            {
                var i = 0;
                foreach (var el in queryParam.Value)
                {
                    var encodedKey = HttpUtility.UrlEncode($"{elementsForScraping.QueryAttribut}{queryParam.Key}][{i}]");
                    var encodedValue = HttpUtility.UrlEncode(el);
                    urlParams.Add($"{encodedKey}={encodedValue}");
                    i++;
                }
            }
        }

        return elementsForScraping.Url + string.Join("&", urlParams);
    }

    private static string BuildEPlanetaScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var queryParam in urlQueryParams)
        {
            var joinedValues = string.Join("%25", queryParam.Value);
            urlParams.Add($"{queryParam.Key}={joinedValues}");
        }

        return elementsForScraping.Url + string.Join("&", urlParams);
    }

    private static string BuildGigatronScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var param in urlQueryParams)
        {
            var keyEncoded = Uri.EscapeDataString(Uri.EscapeDataString(param.Key));
            if (param.Key == "cena")
            {
                var minCena = Uri.EscapeDataString(Uri.EscapeDataString(param.Value.First()));
                var maxCena = Uri.EscapeDataString(Uri.EscapeDataString(urlQueryParams["MaxCena"].First()));
                urlParams.Add($"{keyEncoded}={minCena}..{maxCena}");
                urlQueryParams.Remove("MaxCena");
                continue;
            }

            foreach (var value in param.Value)
            {
                var valueEncoded = Uri.EscapeDataString(Uri.EscapeDataString(value));
                urlParams.Add($"{keyEncoded}={valueEncoded}");
            }
        }
        return elementsForScraping.Url + string.Join("&", urlParams);
    }
}