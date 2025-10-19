using MovieRentalApi.Services.Interfaces;
using MovieRentalApi.Data;
using MovieRentalApi.Models;
using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services;

public class RentalService : IRentalService
{
	private readonly MovieRentalDbContext _context;
	public RentalService(MovieRentalDbContext context)
	{
		_context = context!;
	}
	public async Task<IEnumerable<RentalDto>> GetAllAsync()
	{
		var rentals = _context!.Rentals.ToList();
		return rentals.Select(r => new RentalDto
		{
			Id = r.Id,
			RentedAt = r.RentedAt,
			ReturnedAt = r.ReturnedAt
		});
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

