namespace MovieRentalApi.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public Genre Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; } = false;
    public List<Rental> Rentals { get; set; } = [];
}
