using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using System.Web;

namespace ProductScraper.Scrapers;

public class AnanasScraper : IScrape
{
    public List<string> Scrape(string category, BaseProductFilters selectedFilters)
    {
        var type = selectedFilters.GetType();

        var props = type.GetProperties();
        var filterValuePairs = new Dictionary<string, List<string>>();
        foreach (var prop in props)
        {
            var value = prop.GetValue(selectedFilters);
            if (value != null)
                filterValuePairs.Add(prop.Name, value as List<string>);

        }
        var urlQueryParams = new Dictionary<string, List<string>>();
        if (filterValuePairs.Count != 0)
        {
            Mapper.PropertyNameUrlParamMap.TryGetValue(Constants.Ananas.Name + category, out var ananasLaptopsDict);

            foreach (var key in filterValuePairs.Keys)
            {
                ananasLaptopsDict.TryGetValue(key, out var mappedValue);
                urlQueryParams.Add(mappedValue, filterValuePairs[key]);
            }
        }
        var elementsForScraping = Constants.GetUrlForScraping(Constants.Ananas.Name + category);

        var url = elementsForScraping.Url;
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
        var finalUrl = url + string.Join("&", urlParams);

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--headless=new");
        var driver = new ChromeDriver(chromeOptions);

        driver.Navigate().GoToUrl(finalUrl);
        var html = driver.PageSource;
        var products = driver.FindElements(by: By.ClassName(elementsForScraping.ClassName));
        var a = products.Select(x => x.Text).ToList();
        foreach (var res in a)
        {
            Console.WriteLine(res);
        }
        driver.Quit();
        return a;
    }
}