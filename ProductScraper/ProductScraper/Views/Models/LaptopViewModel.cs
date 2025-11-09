using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Views.Models;

public class LaptopViewModel
{
    public LaptopFilters Filters { get; set; }
    public List<Product> Products { get; set; }
}
