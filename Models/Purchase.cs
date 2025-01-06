namespace TequioDemoTrack.Models;
public class Purchase
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
}


