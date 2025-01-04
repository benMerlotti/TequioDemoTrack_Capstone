namespace TequioDemoTrack.Models.DTOs;
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CustomerProductEmployeeDTO> CustomerProductEmployees { get; set; } = new List<CustomerProductEmployeeDTO>();
}
