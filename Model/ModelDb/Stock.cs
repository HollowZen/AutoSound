namespace AutoSound.Model.ModelDb;

public class Stock
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Comment { get; set; } = null!;

    public decimal? Price { get; set; }
    public int? Count { get; set; }
    public string? Status { get; set; }
}


