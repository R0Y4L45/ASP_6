using Asp_5.Entities;

namespace Asp_5.Models;

public class ProductViewModel
{
    public List<Product>? Products { get; set; }
    public Product? Product { get; set; }
    public string Search { get; set; }
}
