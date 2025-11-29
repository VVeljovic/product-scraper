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

namespace ProductScraper.Scrapers;
using Product = Models.Product;
using ProductEntity = Data.Product;

public class Scraper(ScrapingDbContext scrapingDbContext) : IScrape
{
    public async Task<List<Product>> Scrape(string category, BaseProductFilters filters)
    {
        var filterValuePairs = GetSelectedFilters(filters);

        var filterHashValue = GetHashValueFromFitlers(filters);

        if (!IsAlreadyScraped(filterHashValue))
        {
            var products = new List<Product>();
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
                    url = BuildJakovSistemScrapingUrl(elementsForScraping, urlQueryParams);

                var scrapedProducts = ScrapeProducts(url, elementsForScraping.ScrapingSelectors);

                await SaveProductsAsync(products, filterHashValue);

                products.AddRange(scrapedProducts);
            }
            return products;
        }

        return GetAlreadyScrapedProducts(filterHashValue);

    }

    private async Task SaveProductsAsync(List<Product> products, string filterHashValue)
    {
        var productEntities = products.Adapt<List<ProductEntity>>();
        productEntities.ForEach(x => x.FilterHash = filterHashValue);

        await scrapingDbContext.AddRangeAsync(productEntities);

        await scrapingDbContext.SaveChangesAsync();
    }

    private static List<Product> ScrapeProducts(string finalUrl, ScrapingSelectors scrapingSelectors)
    {
        Console.WriteLine(finalUrl);

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
        var pageSource = driver.PageSource;
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        var productLists = new List<Product>();

        if (!ProductsExist(driver, scrapingSelectors))
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

            productLists.Add(new Product(title, price, link));
        }

        return productLists;
    }

    private static bool ProductsExist(ChromeDriver driver, ScrapingSelectors scrapingSelectors)
    {
        return !driver.FindElements(By.CssSelector(scrapingSelectors.ProductsNotFoundClass)).Any();
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

                    if(Decimal.TryParse(masterValue, out var number))
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
            }

            if (queryParam.Key == "price")
            {
                var encodedKey = HttpUtility.UrlEncode(queryParam.Key);
                var encodedMinPrice = HttpUtility.UrlEncode(queryParam.Value.First());
                var encodedMaxPrice = HttpUtility.UrlEncode(urlQueryParams["MaxPrice"].First());
                urlQueryParams.Remove("MaxPrice");
                urlParams.Add($"{encodedKey}={encodedMinPrice}%3A{encodedMaxPrice}");
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

    private static string BuildJakovSistemScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();
        var resultUrl = elementsForScraping.Url;

        foreach (var pair in urlQueryParams)
        {
            var keyEncoded = HttpUtility.UrlEncode(pair.Key);

            if (pair.Key == "from")
            {
                resultUrl += $"price=asc&{pair.Key}={pair.Value.First()}&to={urlQueryParams["to"].First()}";
                urlQueryParams.Remove("to");
                continue;
            }

            var encodedValues = pair.Value
                .Select(v => HttpUtility.UrlEncode(v));

            var joined = string.Join("§", encodedValues);

            urlParams.Add($"{keyEncoded}={joined}");
        }

        return resultUrl + string.Join("&", urlParams);
    }
}