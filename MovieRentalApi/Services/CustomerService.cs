using Microsoft.EntityFrameworkCore;
using MovieRentalApi.Data;
using MovieRentalApi.Models;
using MovieRentalApi.Dtos;
using MovieRentalApi.Services.Interfaces;
namespace MovieRentalApi.Services;


public class CustomerService : ICustomerService
{
	private readonly MovieRentalDbContext _context;
	public CustomerService(MovieRentalDbContext? context)
	{
		_context = context!;
	}
	public async Task<IEnumerable<CustomerDto>> GetAllAsync()
	{
		var Customers = _context.Customers.ToList();
		return Customers.Select(b => new CustomerDto
		{
			Id = b.Id,
			FirstName = b.FirstName,
			LastName = b.LastName,
			Age = (int)b.Age,
			IsMale = b.IsMale,
			PhoneNumber = b.PhoneNumber,
			Email = b.Email

		});
	}
	public async Task<CustomerDto> GetByIdAsync(int id)
	{
		var customer = await _context!.Customers.FindAsync(id);
		return new CustomerDto
		{
			Id = customer!.Id,
			FirstName = customer.FirstName,
			LastName = customer.LastName,
			Age = customer.Age,
			IsMale = customer.IsMale,
			PhoneNumber = customer.PhoneNumber,
			Email = customer.Email
		};
	}
	public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
	{
		var customer = new Customer
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Age = dto.Age,
			IsMale = dto.IsMale,
			PhoneNumber = dto.PhoneNumber,
			Email = dto.Email
		};

		await _context!.AddAsync(customer);
		await _context!.SaveChangesAsync();

		return new CustomerDto
		{
			FirstName = customer.FirstName,
			LastName = customer.LastName,
			Age = customer.Age,
			IsMale = customer.IsMale,
			PhoneNumber = customer.PhoneNumber,
			Email = customer.Email
		};
	}
	public async Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto dto)
	{
		var customer = await _context!.Customers.FindAsync(id);
		if (customer == null) return null!;

		customer.FirstName = dto.FirstName;
		customer.LastName = dto.LastName;
		customer.Age = dto.Age;
		customer.IsMale = dto.IsMale;
		customer.PhoneNumber = dto.PhoneNumber;
		customer.Email = dto.Email;


		_context.Customers.Update(customer);
		await _context.SaveChangesAsync();
		return new CustomerDto
		{
			Id = customer.Id,
			FirstName = customer.FirstName,
			LastName = customer.LastName,
			Age = customer.Age,
			IsMale = customer.IsMale,
			PhoneNumber = customer.PhoneNumber,
			Email = customer.Email
		};

	}
	public async Task<bool> DeleteAsync(int id)
	{
		var Customer = await _context!.Customers.FindAsync(id);
		if (Customer == null) return false;

		_context.Customers.Remove(Customer);
		await _context.SaveChangesAsync();
		return true;
	}
}

