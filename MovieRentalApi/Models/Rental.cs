namespace MovieRentalApi.Models;

public class Rental
{
    public int Id { get; set; }
    public DateTime RentedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Customer Customer { get; set; } = null!;
    public int CustomerId { get; set; }
    public Movie Movie { get; set; } = null!;
    public int MovieId { get; set; }
}
