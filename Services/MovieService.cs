using MovieRentalApi.Services.Interfaces;
using MovieRentalApi.Data;
using MovieRentalApi.Models;
using MovieRentalApi.Dtos;
using Microsoft.EntityFrameworkCore;
namespace MovieRentalApi.Services;

public class MovieService : IMovieService
{
	private readonly MovieRentalDbContext _context;
	public MovieService(MovieRentalDbContext context)
	{
		_context = context!;
	}
	public async Task<IEnumerable<MovieDto>> GetAllAsync(
		string search,
		int Page,
		int PageSize
	)
	{
		var query = _context.Movies.AsNoTracking();

		if (!string.IsNullOrEmpty(search))
		{
			query = query.Where(m => m.Title.Contains(search));
		}
		var movies = await query
				.OrderBy(m => m.Title)
				.Skip((PageSize - 1) * Page)
				.Take(Page)
				.Select(m => new Movie
				{
					Id = m.Id,
					Title = m.Title,
					Genre = m.Genre,
					ReleaseDate = m.ReleaseDate,
					Price = m.Price
				})
				.ToListAsync();

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

	public async Task<MovieDto> CreateAsync(CreateMovieDto dto)
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

	public async Task<MovieDto> UpdateAsync(int id, UpdateMovieDto dto)
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
