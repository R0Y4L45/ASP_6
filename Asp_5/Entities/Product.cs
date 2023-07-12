using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp_5.Entities;

public class Product
{
    private static int _id = 0;
    public int Id { get; set; }
    
    [DisplayName("Product Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "It is required")]
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "It is required")]
    [RegularExpression(@"^\$?\d+(\.(\d{1}))?$")]
    public decimal Price { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "It is required")]
    [Range(1, 100, ErrorMessage = "The count must be from 1 to 100")]
    public uint Count { get; set; }

    public Product()
    {
        Id = ++_id;
    }
}
