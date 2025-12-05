using ProductScraper.Data;
using ProductScraper.Helpers;
using ProductScraper.Models;
using System.Text;
using System.Web;

namespace ProductScraper.Services.UrlBuilders.Strategy
{
    public class AnanasUrlBuilder : IUrlBuilderStrategy
    {
        public string BuildUrl(ScrapingElements scrapingElements, Dictionary<string, List<string>> urlQueryParams)
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
                        var encodedKey = HttpUtility.UrlEncode($"{"brand"}[{i}]");
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
                        var encodedKey = HttpUtility.UrlEncode($"{scrapingElements.QueryAttribut}{queryParam.Key}][{i}]");
                        var encodedValue = HttpUtility.UrlEncode(el);
                        urlParams.Add($"{encodedKey}={encodedValue}");
                        i++;
                    }
                }
            }
            var url = scrapingElements.Url + string.Join("&", urlParams);

            return url.Replace("+", "%20");
        }

        public string BuildUrl(QueryScrapingModel queryScrapingModel)
        {
            StringBuilder stringBuilder = new StringBuilder(Constants.SitenameUrlPairs[Constants.Ananas.Name]);

            stringBuilder.Replace("queryValue", queryScrapingModel.Query);
            stringBuilder.Replace(" ", "%20");

            stringBuilder.Replace("priceValue", $"{queryScrapingModel.MinPrice.ToString()}%3A{queryScrapingModel.MaxPrice.ToString()}");

            return stringBuilder.ToString();
        }
    }
}
