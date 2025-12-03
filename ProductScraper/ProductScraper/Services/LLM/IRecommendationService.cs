using ProductScraper.Models;

namespace ProductScraper.Services.LLM
{
    public interface IRecommendationService
    {
        public Task<string> GenerateRecommendation(List<Product> products);
    }
}
