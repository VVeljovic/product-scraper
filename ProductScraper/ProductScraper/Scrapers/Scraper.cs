using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using System.Security.Policy;
using System.Web;

namespace ProductScraper.Scrapers;

public class Scraper : IScrape
{
    public List<string> Scrape(string category, string siteName, BaseProductFilters filters)
    {
        var filterValuePairs = GetSelectedFilters(filters);

        var urlQueryParams = BuildUrlQueryParams(siteName + category, filterValuePairs);
        var elementsForScraping = Constants.GetUrlForScraping(siteName + category);

        var url = string.Empty; 
        if (siteName == Constants.Ananas.Name)
            url = BuildAnanasScrapingUrl(elementsForScraping, urlQueryParams);
        else if (siteName == Constants.Gigatron.Name)
            url = BuildGigatronScrapingUrl(elementsForScraping, urlQueryParams);
        else
            url = BuildEplanetaScrapingUrl(elementsForScraping, urlQueryParams);

        return ScrapeProducts(url, elementsForScraping.ClassName);
    }

    private static List<string> ScrapeProducts(string finalUrl, string elementClassName)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--headless=new");
        var driver = new ChromeDriver(chromeOptions);

        driver.Navigate().GoToUrl(finalUrl);
        var html = driver.PageSource;
        var products = driver.FindElements(by: By.ClassName(elementClassName));
        var a = products.Select(x => x.Text).ToList();
        foreach (var res in a)
        {
            Console.WriteLine(res);
        }
        driver.Quit();
        return a;
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

    private static string BuildEplanetaScrapingUrl(ScrapingElements elementsForScraping, Dictionary<string, List<string>> urlQueryParams)
    {
        var urlParams = new List<string>();

        return string.Empty;
    }
}