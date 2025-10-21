using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services.Interfaces;

public interface ICustomerService
{
	Task<IEnumerable<CustomerDto>> GetAllAsync(
		string search,
		int Page,
		int PageSize
	);
	Task<CustomerDto> GetByIdAsync(int id);
	Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
	Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto dto);
	Task<bool> DeleteAsync(int id);
}
