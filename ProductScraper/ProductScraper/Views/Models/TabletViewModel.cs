using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Views.Models;

public class TabletViewModel
{
    public TabletsFilters Filters { get; set; }
    public List<Product> Products { get; set; }
}
