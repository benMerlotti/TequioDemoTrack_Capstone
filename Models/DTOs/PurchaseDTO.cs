namespace TequioDemoTrack.Models.DTOs;

public class PurchaseDTO
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; } = null!;
    public int EmployeeId { get; set; }
    public EmployeeDTO Employee { get; set; } = null!;

    public ICollection<PurchaseProductDTO> PurchaseProducts { get; set; } = new List<PurchaseProductDTO>();
}

public class CreatePurchaseDTO
{
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public ICollection<CreatePurchaseProductDTO> PurchaseProducts { get; set; } = new List<CreatePurchaseProductDTO>();
}

