namespace MovieRentalApi.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty!;
    public string LastName { get; set; } = string.Empty!;
    public int Age { get; set; }
    public bool IsMale { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; } = string.Empty!;
    public bool IsDeleted { get; set; } = false;
    public List<Rental> Rentals { get; set; } = [];
}
