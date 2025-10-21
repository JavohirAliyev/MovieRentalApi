using Microsoft.AspNetCore.Mvc;
using MovieRentalApi.Dtos;
using MovieRentalApi.Services.Interfaces;

namespace MovieRentalApi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService _movieService;
		public MovieController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(
				[FromQuery] string search = "",
				[FromQuery] int page = 1,
				[FromQuery] int pageSize = 10,
				CancellationToken ct = default
		)
		{
			var movies = await _movieService.GetAllAsync(
				search,
				page,
				pageSize);
			return Ok(movies);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var movie = await _movieService.GetByIdAsync(id);
			return Ok(movie);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateMovieDto dto)
		{
			var movie = await _movieService.CreateAsync(dto);
			return Ok(movie);
		}

		[HttpPut("{Id}")]
		public async Task<IActionResult> Update(int id, UpdateMovieDto dto)
		{
			var movie = await _movieService.UpdateAsync(id, dto);
			if (movie == null) return NotFound();
			return Ok(movie);
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _movieService.DeleteAsync(id);
			if (!result) return NotFound();
			return NoContent();
		}
	}
}