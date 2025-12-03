using OpenAI;
using OpenAI.Chat;
using ProductScraper.Models;
using System.Text.Json;

namespace ProductScraper.Services.LLM
{
    public class RecommendationService : IRecommendationService
    {
        public async Task<string> GenerateRecommendation(List<Product> products)
        {
            var modelName = "gpt-4o";

            var client = new ChatClient();

            var serializedProducts = JsonSerializer.Serialize(products);

            var message = "Od ovih proizvoda daj mi najbolje preporuke u odnosu na performanse i cenu " + serializedProducts;

            var response = await client.CompleteChatAsync(message);

            Console.WriteLine(response.Value.Content[0].Text);

            return response.Value.Content[0].Text;
        }
    }
}
