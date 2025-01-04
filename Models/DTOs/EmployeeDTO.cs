namespace TequioDemoTrack.Models.DTOs;
public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public ICollection<CustomerProductEmployeeDTO> CustomerProductEmployees { get; set; } = new List<CustomerProductEmployeeDTO>();
}
