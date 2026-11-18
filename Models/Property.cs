using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PropertyCrmLab.Models;

public class Property
{
	[Key]
	public int Id { get; set; }

	[Required]
	[MaxLength(200)]
	public string Address { get; set; } = string.Empty;

	public decimal Area { get; set; }

	public decimal RentPrice { get; set; }

	public List<Tenant> Tenants { get; set; } = new();
}