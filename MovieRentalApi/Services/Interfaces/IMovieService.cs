
using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services.Interfaces;

public interface IMovieService
{
	Task<IEnumerable<MovieDto>> GetAllAsync(
		string search,
		int Page,
		int PageSize);
	Task<MovieDto> GetByIdAsync(int id);
	Task<MovieDto> CreateAsync(CreateMovieDto dto);
	Task<MovieDto> UpdateAsync(int id, UpdateMovieDto dto);
	Task<bool> DeleteAsync(int id);
}
