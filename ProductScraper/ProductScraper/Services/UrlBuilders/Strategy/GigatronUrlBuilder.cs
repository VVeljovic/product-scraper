using ProductScraper.Helpers;
using ProductScraper.Models;
using System.Text;

namespace ProductScraper.Services.UrlBuilders.Strategy
{
    public class GigatronUrlBuilder : IUrlBuilderStrategy
    {
        public string BuildUrl(ScrapingElements scrapingElements, Dictionary<string, List<string>> urlQueryParams)
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
            return scrapingElements.Url + string.Join("&", urlParams);
        }

        public string BuildUrl(QueryScrapingModel queryScrapingModel)
        {
            StringBuilder stringBuilder = new StringBuilder(Constants.SitenameUrlPairs[Constants.Gigatron.Name]);

            stringBuilder.Replace("queryValue", queryScrapingModel.Query);
            stringBuilder.Replace(" ", "+");
            stringBuilder.Replace("priceValue", $"{queryScrapingModel.MinPrice.ToString()}..{queryScrapingModel.MaxPrice.ToString()}");

            return stringBuilder.ToString();
        }
    }
}
