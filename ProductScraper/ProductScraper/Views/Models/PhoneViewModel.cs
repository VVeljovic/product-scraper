using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Views.Models;

public class PhoneViewModel
{
    public PhonesFilters Filters { get; set; }
    public List<Product> Products { get; set; }
}
