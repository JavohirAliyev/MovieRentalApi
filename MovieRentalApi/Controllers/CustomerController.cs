using Microsoft.AspNetCore.Mvc;
using MovieRentalApi.Dtos;
using MovieRentalApi.Services;
using MovieRentalApi.Services.Interfaces;

namespace MovieRentalApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;
		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(
				[FromQuery] string search = "",
				[FromQuery] int page = 1,
				[FromQuery] int pageSize = 10,
				CancellationToken ct = default)
		{
			var customers = await _customerService.GetAllAsync(search, page, pageSize);
			return Ok(customers);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var customer = await _customerService.GetByIdAsync(id);
			return Ok(customer);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCustomerDto dto)
		{
			var customer = await _customerService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
		}

		[HttpPut("{Id}")]
		public async Task<IActionResult> Update(int id, UpdateCustomerDto dto)
		{
			var customer = await _customerService.UpdateAsync(id, dto);
			if (customer == null) return NotFound();
			return Ok(customer);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _customerService.DeleteAsync(id);
			if (!result) return NotFound();
			return NoContent();
		}
	}
}
