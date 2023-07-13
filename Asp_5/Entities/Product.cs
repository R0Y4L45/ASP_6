namespace Asp_5.Entities;

public class Product
{
    private static int _id = 0;
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public uint Count { get; set; }

    public Product()
    {
        Id = ++_id;
    }
}
