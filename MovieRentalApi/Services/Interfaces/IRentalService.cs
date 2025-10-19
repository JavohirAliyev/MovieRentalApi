using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services.Interfaces;

public interface IRentalService
{
	Task<IEnumerable<RentalDto>> GetAllAsync();
	Task<RentalDto> GetByIdAsync(int id);
	Task<RentalDto> CreateAsync(RentalDto dto);
	Task<RentalDto> UpdateAsync(int id, RentalDto dto);
	Task<bool> DeleteAsync(int id);
}
