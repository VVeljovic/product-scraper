using ProductScraper.Helpers;
using ProductScraper.Models;
using System.Text;

namespace ProductScraper.Services.UrlBuilders.Strategy
{
    public class EPlanetaUrlBuilder : IUrlBuilderStrategy
    {
        public string BuildUrl(ScrapingElements scrapingElements, Dictionary<string, List<string>> urlQueryParams)
        {
            var urlParams = new List<string>();

            foreach (var queryParam in urlQueryParams)
            {
                if(queryParam.Key == "price")
                {
                    urlParams.Add($"{queryParam.Key}={queryParam.Value.First().ToString()}-{urlQueryParams["MaxCena"].First().ToString()}");
                    urlQueryParams.Remove("MaxCena");
                    continue;
                }

                var joinedValues = string.Join("%25", queryParam.Value);
                urlParams.Add($"{queryParam.Key}={joinedValues}");
            }

            return scrapingElements.Url + string.Join("&", urlParams);
        }

        public string BuildUrl(QueryScrapingModel queryScrapingModel)
        {
            StringBuilder stringBuilder = new StringBuilder(Constants.SitenameUrlPairs[Constants.EPlaneta.Name]);

            stringBuilder.Replace("queryValue", queryScrapingModel.Query);
            stringBuilder.Replace(" ", "+");
            stringBuilder.Replace("priceValue", $"{queryScrapingModel.MinPrice.ToString()}-{queryScrapingModel.MaxPrice.ToString()}");

            return stringBuilder.ToString();
        }
    }
}
