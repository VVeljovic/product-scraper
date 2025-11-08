//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using ProductScrapper.Helpers;
//using ProductScrapper.Models.Filters;

//namespace ProductScrapper;

//public sealed class ScrapperService : IScrapeService
//{

//    public Task Scrape(Dictionary<string, string> urlAndTargetElementClassNameMap)
//    {
//        foreach (var element in urlAndTargetElementClassNameMap)
//        {
//            var chromeOptions = new ChromeOptions();
//            chromeOptions.AddArguments("--headless=new");
//            var driver = new ChromeDriver(chromeOptions);

//            driver.Navigate().GoToUrl(element.Key);
//            var html = driver.PageSource;
//            var products = driver.FindElements(by: By.ClassName(element.Value));
//            var a = products.Select(x => x.Text);
//            driver.Quit();
//        }

//        return;
//    }

//    public async Task ScrapeLaptops(Filteri filteri)
//    {
//        BuildUrlsForScrapping(filteri);
//    }

//    public List<string> BuildUrlsForScrapping(Filteri filteri, Category category)
//    {
//        var categoryName = category.ToString();
//        var categoryPath = typeof(Constants.Ananas)
//                        .GetField(categoryName)?
//                        .GetValue(null)?
//                        .ToString();

//        var relativeUrl = Constants.Ananas.BaseUrl + categoryPath;

//    }

//    public List<string> MapFilters(Filteri filteri, string categoryName)
//    {
//        var ananasMapping = Mapper.PropertyNameUrlParamMap["Ananas" + categoryName];

//        var lista = new List<string>();

//        foreach (var map in ananasMapping)
//        {
//            lista = ananasMapping.Values.ToList();
//        }

//        return lista;
//    }

//}
