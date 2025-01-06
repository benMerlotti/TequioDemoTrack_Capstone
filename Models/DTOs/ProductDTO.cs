namespace TequioDemoTrack.Models.DTOs;
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<PurchaseProductDTO> PurchaseProducts { get; set; } = new List<PurchaseProductDTO>();

}

public class CreateProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

}
