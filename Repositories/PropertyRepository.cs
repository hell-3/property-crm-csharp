using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyCrmLab.Models;
using PropertyCrmLab.Data;

namespace PropertyCrmLab.Repositories;

public class PropertyRepository
{
	private readonly AppDbContext _context;

	public PropertyRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<Property>> GetAllAsync()
	{
		return await _context.Properties.Include(p => p.Tenants).ToListAsync();
	}

	public async Task<Property?> GetByIdAsync(int id)
	{
		return await _context.Properties
			.Include(p => p.Tenants)
			.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task AddAsync(Property property)
	{
		await _context.Properties.AddAsync(property);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Property property)
	{
		_context.Properties.Update(property);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var property = await _context.Properties.FindAsync(id);
		if (property != null)
		{
			_context.Properties.Remove(property);
			await _context.SaveChangesAsync();
		}
	}
}