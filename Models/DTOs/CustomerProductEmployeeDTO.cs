namespace TequioDemoTrack.Models.DTOs;
public class CustomerProductEmployeeDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductDTO Product { get; set; } = null!;
    public int EmployeeId { get; set; }
    public EmployeeDTO Employee { get; set; } = null!;
    public DateTime PurchaseDate { get; set; }
}

public class PurchaseDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime PurchaseDate { get; set; }
}
