using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services.Interfaces;

public interface ICustomerService
{
	Task<IEnumerable<CustomerDto>> GetAllAsync();
	Task<CustomerDto> GetByIdAsync(int id);
	Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
	Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto dto);
	Task<bool> DeleteAsync(int id);
}
