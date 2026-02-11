
public class ProductListViewModel
{
    public List<Product> Products { get; set; } = new();

    public string? Search { get; set; }
    public string? Category { get; set; }
    public string? Sort { get; set; }

    public List<string> Categories { get; set; } = new();
}
