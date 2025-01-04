namespace TequioDemoTrack.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CustomerProductEmployee> CustomerProductEmployees { get; set; } = new List<CustomerProductEmployee>();
}
