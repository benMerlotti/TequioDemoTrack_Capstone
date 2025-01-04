using System.ComponentModel.DataAnnotations;

namespace TequioDemoTrack.Models;
public class Customer
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public int AgeGroupId { get; set; }
    public AgeGroup AgeGroup { get; set; } = null!;
    [Required]
    public int GenderId { get; set; }
    public Gender Gender { get; set; } = null!;
    [Required]
    public int RaceId { get; set; }
    public Race Race { get; set; } = null!;
    [Required]
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public ICollection<CustomerProductEmployee> Purchases { get; set; } = new List<CustomerProductEmployee>();
}
