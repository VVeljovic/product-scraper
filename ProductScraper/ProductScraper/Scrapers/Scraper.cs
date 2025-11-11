using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductScraper.Data;
using ProductScraper.Helpers;
using ProductScraper.Models;
using ProductScraper.Models.Filters;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Mapster;

namespace ProductScraper.Scrapers;
using Product = Models.Product;
using ProductEntity = Data.Product;

public class Scraper(ProductsDbContext productsDbContext) : IScrape
{
    public async Task<List<Product>> Scrape(string category, string siteName, BaseProductFilters filters)
    {
        var filterValuePairs = GetSelectedFilters(filters);

        var filterHashValue = GetHashValueFromFitlers(filters);

        if (!IsAlreadyScraped(filterHashValue))
        {
            var urlQueryParams = BuildUrlQueryParams(siteName + category, filterValuePairs);
            var elementsForScraping = Constants.GetUrlForScraping(siteName + category);

            var url = string.Empty;
            if (siteName == Constants.Ananas.Name)
                url = BuildAnanasScrapingUrl(elementsForScraping, urlQueryParams);
            else if (siteName == Constants.Gigatron.Name)
                url = BuildGigatronScrapingUrl(elementsForScraping, urlQueryParams);
            else
                url = BuildJakovSistemScrapingUrl(elementsForScraping, urlQueryParams);

            var products = ScrapeProducts(url, elementsForScraping.ScrapingSelectors);

            await SaveProductsAsync(products, filterHashValue);
           
            return products;
        }

        return GetAlreadyScrapedProducts(filterHashValue);

    }

    private async Task SaveProductsAsync(List<Product> products, string filterHashValue)
    {
        var productEntities = products.Adapt<List<ProductEntity>>();
        productEntities.ForEach(x => x.FilterHash = filterHashValue);

        await productsDbContext.AddRangeAsync(productEntities);

        await productsDbContext.SaveChangesAsync();
    }

    private static List<Product> ScrapeProducts(string finalUrl, ScrapingSelectors scrapingSelectors)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--headless=new");
        var driver = new ChromeDriver(chromeOptions);

        driver.Navigate().GoToUrl(finalUrl);
        var products = ExtractProductsDetails(driver, scrapingSelectors);
        driver.Quit();
        return products;
    }

    private static List<Product> ExtractProductsDetails(ChromeDriver driver, ScrapingSelectors scrapingSelectors)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElements(by: By.XPath(scrapingSelectors.DivClass)).Count > 0);
        var productDivs = driver.FindElements(by: By.XPath(scrapingSelectors.DivClass));
        var productLists = new List<Product>();

        foreach (var productDiv in productDivs)
        {
            var aTag = productDiv.FindElement(By.CssSelector("a.w-full.h-full"));
            var title = productDiv.FindElement(By.ClassName(scrapingSelectors.TitleClass)).Text;
            var link = aTag.GetAttribute("href");
            var price = "";

            productLists.Add(new Product(title, price, link));
        }

        return productLists;
    }

    private bool IsAlreadyScraped(string hashValue)
    {
        return productsDbContext.Products.Any(x => x.FilterHash == hashValue);            
    }

    private List<Product> GetAlreadyScrapedProducts(string hashValue)
    {
        var productEntities = productsDbContext.Products.Where(x => x.FilterHash == hashValue).ToList();

        return productEntities.Adapt<List<Product>>();
    }

    private static string GetHashValueFromFitlers(BaseProductFilters filters)
    {
        using (var md5 = MD5.Create())
        {
            var serializedFilters = JsonSerializer.Serialize(filters);

            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(serializedFilters));

            return BitConverter.ToString(hashBytes).Replace("-","");
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
            if (value != null)
                filterValuePairs.Add(prop.Name, value as List<string>);
        }

        return filterValuePairs;
    }

    private static Dictionary<string, List<string>> BuildUrlQueryParams(string siteNameCategoryName, Dictionary<string, List<string>> filterValuePairs)
    {
        var urlQueryParams = new Dictionary<string, List<string>>();
        if (filterValuePairs.Count != 0)
        {
            Mapper.PropertyNameUrlParamMap.TryGetValue(siteNameCategoryName, out var ananasLaptopsDict);

            foreach (var key in filterValuePairs.Keys)
            {
                ananasLaptopsDict.TryGetValue(key, out var mappedValue);
                urlQueryParams.Add(mappedValue, filterValuePairs[key]);
            }
        }

        return urlQueryParams;
    }

    private static string BuildAnanasScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var pairs in urlQueryParams)
        {
            if (pairs.Key == "brand")
            {
                var i = 0;
                var vls = pairs.Value;
                foreach (var value in vls)
                {
                    var encodedKey = HttpUtility.UrlEncode($"{Constants.Ananas.Phones.Brend}[{i}]");
                    var encodedValue = HttpUtility.UrlEncode(value);
                    urlParams.Add($"{encodedKey}={encodedValue}");
                    i++;
                }
            }
            else
            {
                var i = 0;
                foreach (var el in pairs.Value)
                {
                    var encodedKey = HttpUtility.UrlEncode($"{elementsForScraping.QueryAttribut}{pairs.Key}][{i}]");
                    var encodedValue = HttpUtility.UrlEncode(el);
                    urlParams.Add($"{encodedKey}={encodedValue}");
                    i++;
                }
            }
        }

        return elementsForScraping.Url + string.Join("&", urlParams);
    }

    private static string BuildGigatronScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var pairs in urlQueryParams)
        {
            var keyEncoded = Uri.EscapeDataString(Uri.EscapeDataString(pairs.Key));
            foreach (var value in pairs.Value)
            {
                var valueEncoded = Uri.EscapeDataString(Uri.EscapeDataString(value));
                urlParams.Add($"{keyEncoded}={valueEncoded}");
            }
        }
        return elementsForScraping.Url + string.Join("&", urlParams);
    }

    private static string BuildJakovSistemScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        foreach (var pairs in urlQueryParams)
        {
            var keyEncoded = HttpUtility.UrlEncode(pairs.Key);
            foreach (var value in pairs.Value)
            {
                var valueEncoded = HttpUtility.UrlEncode(value);
                urlParams.Add($"{keyEncoded}={valueEncoded}");
            }
        }
        return elementsForScraping.Url + string.Join("&", urlParams);
    }
}