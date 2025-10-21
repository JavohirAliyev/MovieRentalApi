using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services.Interfaces;

public interface IRentalService
{
	Task<IEnumerable<RentalDto>> GetAllAsync(
		string search,
		int Page,
		int PageSize
	);
	Task<RentalDto> GetByIdAsync(int id);
	Task<RentalDto> CreateAsync(CreateRentalDto dto);
	Task<RentalDto> UpdateAsync(int id, UpdateRentalDto dto);
	Task<bool> DeleteAsync(int id);
}
