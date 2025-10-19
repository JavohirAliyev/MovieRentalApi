using MovieRentalApi.Services.Interfaces;
using MovieRentalApi.Data;
using MovieRentalApi.Models;
using MovieRentalApi.Dtos;
namespace MovieRentalApi.Services;

public class MovieService : IMovieService
{
	private readonly MovieRentalDbContext _context;
	public MovieService(MovieRentalDbContext context)
	{
		_context = context!;
	}
	public async Task<IEnumerable<MovieDto>> GetAllAsync()
	{
		var movies = _context!.Movies.ToList();

		return movies.Select(m => new MovieDto
		{
			Id = m.Id,
			Title = m.Title,
			Genre = Enum.GetValues<Genre>()
						.Where(g => g != Genre.None && m.Genre.HasFlag(g))
						.Select(g => g.ToString())
						.ToList(),
			ReleaseDate = m.ReleaseDate,
			Price = m.Price
		});
	}
	public async Task<MovieDto> GetByIdAsync(int id)
	{
		var movie = await _context!.Movies.FindAsync(id);
		if (movie == null) return null!;
		return new MovieDto
		{
			Id = movie.Id,
			Title = movie.Title,
			Genre = Enum.GetValues<Genre>()
							.Where(g => g != Genre.None && movie.Genre.HasFlag(g))
							.Select(g => g.ToString())
							.ToList(),
			ReleaseDate = movie.ReleaseDate,
			Price = movie.Price
		};
	}
	public async Task<MovieDto> CreateAsync(MovieDto dto)
	{
		var movie = new Movie
		{
			Title = dto.Title,
			Genre = dto.Genre
						.Select(Enum.Parse<Genre>)
						.Aggregate(Genre.None, (current, next) => current | next),
			ReleaseDate = dto.ReleaseDate,
			Price = dto.Price,
		};

		await _context!.AddAsync(movie);
		await _context.SaveChangesAsync();
		return new MovieDto
		{
			Title = movie.Title,
			Genre = Enum.GetValues<Genre>()
							.Where(g => g != Genre.None && movie.Genre.HasFlag(g))
							.Select(g => g.ToString())
							.ToList(),
			ReleaseDate = movie.ReleaseDate,
			Price = movie.Price
		};
	}
	public async Task<MovieDto> UpdateAsync(int id, MovieDto dto)
	{
		var movie = await _context.Movies.FindAsync(id);
		if (movie == null) return null!;
		movie.Title = dto.Title;
		movie.Genre = dto.Genre
			.Select(Enum.Parse<Genre>)
			.Aggregate(Genre.None, (current, next) => current | next);
		movie.ReleaseDate = dto.ReleaseDate;
		movie.Price = dto.Price;

		_context.Movies.Update(movie);
		await _context!.SaveChangesAsync();

		return new MovieDto
		{
			Title = movie.Title,
			Genre = Enum.GetValues<Genre>()
				.Where(g => g != Genre.None && movie.Genre.HasFlag(g))
				.Select(g => g.ToString())
				.ToList(),
			ReleaseDate = movie.ReleaseDate,
			Price = movie.Price
		};
	}
	public async Task<bool> DeleteAsync(int id)
	{
		var Movie = await _context!.Movies.FindAsync(id);
		if (Movie == null) return false;

		_context.Movies.Remove(Movie);
		await _context.SaveChangesAsync();

		return true;
	}
}
