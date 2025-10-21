// using Microsoft.AspNetCore.Mvc;
// using MovieRentalApi.Dtos;
// using MovieRentalApi.Services;
// using MovieRentalApi.Services.Interfaces;

// namespace MovieRentalApi.Controllers
// {
// 	[ApiController]
// 	[Route("api/[Controller]")]
// 	public class CustomerController : ControllerBase
// 	{
// 		private readonly ICustomerService _customerService;
// 		public CustomerController(ICustomerService customerService)
// 		{
// 			_customerService = customerService;
// 		}


// 		[HttpGet]
// 		public async Task<IActionResult> GetAll()
// 		{
// 			var customers = await _customerService.GetAllAsync();
// 			return Ok(customers);
// 		}


// 		[HttpGet("{Id}")]
// 		public async Task<IActionResult> GetById(int id)
// 		{
// 			var customer = await _customerService.GetByIdAsync(id);
// 			return Ok(customer);
// 		}

// 		[HttpPost]
// 		public async Task<IActionResult> Create(CreateCustomerDto dto)
// 		{
// 			var customer = await _customerService.CreateAsync(dto);
// 			return CreatedAtAction(GetById)
// 		}





// 	}
// }