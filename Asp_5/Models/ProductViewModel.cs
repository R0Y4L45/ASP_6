using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Asp_5.Models;

public class ProductViewModel
{
    [DisplayName("Product Name")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Required(ErrorMessage = "It is required")]
    [RegularExpression(@"^\$?\d+(\.(\d{1}))?$")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "It is required")]
    [Range(1, 100, ErrorMessage = "The count must be from 1 to 100")]
    public uint Count { get; set; }
}
