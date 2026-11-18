using Microsoft.EntityFrameworkCore;
using PropertyCrmLab.Models;

namespace PropertyCrmLab.Data;

public class AppDbContext : DbContext
{
	public DbSet<Property> Properties => Set<Property>();
	public DbSet<Tenant> Tenants => Set<Tenant>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql("Host=localhost;Database=property_crm_lab;Username=postgres;Password=12345");
	}
}