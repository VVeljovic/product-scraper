using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Views.Models;

public class DesktopViewModel
{
    public DesktopFilters Filters { get; set; }
    public List<Product> Products { get; set; }
}
