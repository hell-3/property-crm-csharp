using System.ComponentModel.DataAnnotations;

namespace PropertyCrmLab.Models;

public class Tenant
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    public int PropertyId { get; set; }
    public Property? Property { get; set; }
}