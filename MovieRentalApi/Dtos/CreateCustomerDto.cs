namespace MovieRentalApi.Dtos
{
    public class CreateCustomerDto
    {
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty!;
    
    }
}