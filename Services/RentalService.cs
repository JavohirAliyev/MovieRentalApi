using MovieRentalApi.Services.Interfaces;
using MovieRentalApi.Data;
using MovieRentalApi.Models;
using MovieRentalApi.Dtos;
using Microsoft.EntityFrameworkCore;
namespace MovieRentalApi.Services;

public class RentalService : IRentalService
{
	private readonly MovieRentalDbContext _context;
	public RentalService(MovieRentalDbContext context)
	{
		_context = context!;
	}

	public async Task<IEnumerable<RentalDto>> GetAllAsync(
		string search,
		int Page,
		int PageSize)
	{
		var query = _context!.Rentals.AsNoTracking();
		if (!string.IsNullOrEmpty(search))
		{
			query = query.Where(r => r.Id.ToString().Contains(search) ||
			r.RentedAt.ToString().Contains(search) ||
			r.ReturnedAt.ToString().Contains(search));
		}
		var rental = await query
			 .OrderBy(r => r.RentedAt)
			 .Skip((Page - 1) * PageSize)
			 .Take(PageSize)
			 .Select(b => new RentalDto
			 {
				 Id = b.Id,
				 RentedAt = b.RentedAt,
				 ReturnedAt = b.ReturnedAt
			 })
			 .ToListAsync();

		return rental;
	}

	public async Task<RentalDto> GetByIdAsync(int id)
	{
		var rental = await _context!.Rentals.FindAsync(id);
		return new RentalDto
		{
			Id = rental!.Id,
			RentedAt = rental.RentedAt,
			ReturnedAt = rental.ReturnedAt,
		};
	}

	public async Task<RentalDto> CreateAsync(RentalDto dto)
	{
		var rental = new Rental
		{
			RentedAt = dto.RentedAt,
			ReturnedAt = dto.ReturnedAt,
		};
		await _context!.AddAsync(rental);
		await _context.SaveChangesAsync();
		return new RentalDto
		{
			RentedAt = rental.RentedAt,
			ReturnedAt = rental.ReturnedAt,
		};
	}

	public async Task<RentalDto> UpdateAsync(int id, RentalDto dto)
	{
		var rental = await _context.Rentals.FindAsync(id);
		if (rental == null) return null!;
		rental.RentedAt = dto.RentedAt;
		rental.ReturnedAt = dto.ReturnedAt;

		_context.Update(rental);
		await _context.SaveChangesAsync();
		return new RentalDto
		{
			Id = rental.Id,
			RentedAt = rental.RentedAt,
			ReturnedAt = rental.ReturnedAt,
		};
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var Rental = await _context!.Rentals.FindAsync(id);
		if (Rental == null) return false!;
		_context.Rentals.Remove(Rental);
		await _context.SaveChangesAsync();
		return true;
	}
}
