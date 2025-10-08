namespace MovieRentalApi.Models;
public class Rental
{
    public int Id { get; set; }
    public DateTime RentedAt { get; set; } = DateTime.Now;
    public DateTime? ReturnedAt { get; set; }
}