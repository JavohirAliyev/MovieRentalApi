using Microsoft.AspNetCore.Mvc;
using MovieRentalApi.Dtos;
using MovieRentalApi.Models;
using MovieRentalApi.Services;
using MovieRentalApi.Services.Interfaces;

namespace MovieRentalApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class RentalController : ControllerBase
	{
		private readonly IRentalService _rentalService;

		public RentalController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(
				[FromQuery] string search = "",
				[FromQuery] int page = 1,
				[FromQuery] int pageSize = 10,
				CancellationToken ct = default
		)
		{
			var rental = await _rentalService.GetAllAsync(
				search,
				page,
				pageSize
			);
			return Ok(rental);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var customer = await _rentalService.GetByIdAsync(id);
			return Ok(customer);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateRentalDto dto)
		{
			var customer = await _rentalService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
		}

		[HttpPut("{Id}")]
		public async Task<IActionResult> Update(int id, UpdateRentalDto dto)
		{
			var customer = await _rentalService.UpdateAsync(id, dto);
			if (customer == null) return NotFound();
			return Ok(customer);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _rentalService.DeleteAsync(id);
			if (!result) return NotFound();
			return NoContent();
		}

	}
}